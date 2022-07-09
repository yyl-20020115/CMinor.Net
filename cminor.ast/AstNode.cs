using CMinor.Parser;
using CMinor.semantic;
using CMinor.Symbol;
using CMinor.Visit;
using System.Collections;
using System.IO;
using System.Text;

namespace CMinor.AST;

public abstract class AstNode : DotNode
{
	
	internal sealed class Edge
	{
		public DotNode source;

		public DotNode dest;

		
		
		public Edge(DotNode P_0, DotNode P_1)
		{
			source = P_0;
			dest = P_1;
		}
	}

	private static int numInstances;

	private int instanceNumber;

	private LocationInfo location;

	
	
	public virtual void Accept(Visitor v)
	{
		v.visit(this);
	}
	private void getNodesAndEdges(ChildVisitor P_0, GetSymbolVisitor P_1, List P_2, List P_3, List P_4, List P_5)
	{
		P_2.add(this);
		ArrayList arrayList = new ArrayList();
		P_0.setChildren(arrayList);
		Accept(P_0);
		Iterator iterator = ((List)arrayList).iterator();
		while (iterator.hasNext())
		{
			AstNode astNode = (AstNode)iterator.next();
			P_3.add(new Edge(this, astNode));
			astNode.getNodesAndEdges(P_0, P_1, P_2, P_3, P_4, P_5);
		}
		ArrayList arrayList2 = new ArrayList();
		P_1.setSymbols(arrayList2);
		Accept(P_1);
		Iterator iterator2 = ((List)arrayList2).iterator();
		while (iterator2.hasNext())
		{
			CMinor.Symbol.Symbol symbol = (CMinor.Symbol.Symbol)iterator2.next();
			if (symbol != null)
			{
				P_4.add(symbol);
				P_5.add(new Edge(this, symbol));
			}
		}
	}

	
	
	public virtual string getDotId()
	{
		string result = new StringBuilder().append("AstNode").append(instanceNumber).toString();
		
		return result;
	}

	
	
	protected internal AstNode(LocationInfo location)
	{
		instanceNumber = numInstances++;
		this.location = location;
	}

	public virtual LocationInfo getLocation()
	{
		return location;
	}

	
	
	public virtual string getDotLabel()
	{
		DotLabelVisitor dotLabelVisitor = new DotLabelVisitor();
		Accept(dotLabelVisitor);
		string label = dotLabelVisitor.getLabel();
		
		return label;
	}

	public void printDotCode(TextWriter output)
	{
		DotLabelVisitor dotLabelVisitor = new DotLabelVisitor();
		ChildVisitor childVisitor = new ChildVisitor();
		SymbolDotLabelVisitor symbolDotLabelVisitor = new SymbolDotLabelVisitor();
		GetSymbolVisitor getSymbolVisitor = new GetSymbolVisitor();
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		ArrayList arrayList4 = new ArrayList();
		getNodesAndEdges(childVisitor, getSymbolVisitor, arrayList, arrayList2, arrayList3, arrayList4);
		output.println("digraph {");
		output.println("\tgraph [ordering=\"out\"];");
		Iterator iterator = ((List)arrayList).iterator();
		while (iterator.hasNext())
		{
			AstNode astNode = (AstNode)iterator.next();
			astNode.Accept(dotLabelVisitor);
			output.println(new StringBuilder().append("\t").append(astNode.getDotId()).append(" [label=\"")
				.append(dotLabelVisitor.getLabel())
				.append("\"];")
				.toString());
		}
		iterator = ((List)arrayList2).iterator();
		while (iterator.hasNext())
		{
			Edge edge = (Edge)iterator.next();
			output.println(new StringBuilder().append("\t").append(edge.source.getDotId()).append(" -> ")
				.append(edge.dest.getDotId())
				.append(";")
				.toString());
		}
		iterator = ((List)arrayList3).iterator();
		while (iterator.hasNext())
		{
			CMinor.Symbol.Symbol symbol = (CMinor.Symbol.Symbol)iterator.next();
			symbol.accept(symbolDotLabelVisitor);
			output.println(new StringBuilder().append("\t").append(symbol.getDotId()).append(" [label=\"")
				.append(symbolDotLabelVisitor.getLabel())
				.append("\", shape=box]")
				.toString());
		}
		iterator = ((List)arrayList4).iterator();
		while (iterator.hasNext())
		{
			Edge edge = (Edge)iterator.next();
			output.println(new StringBuilder().append("\t").append(edge.source.getDotId()).append(" -> ")
				.append(edge.dest.getDotId())
				.append(" [style=\"dashed\"];")
				.toString());
		}
		output.println("}");
	}

	
	
	public void resolveSymbols(ErrorLogger logger)
	{
		Accept(new SymbolResolutionVisitor(logger));
	}

	
	
	public void typeCheck(ErrorLogger logger)
	{
		Accept(new TypeCheckVisitor(logger));
	}

	
	
	public void generateCode(TextWriter output)
	{
		Accept(new CodeGenerationVisitor(output));
	}
}
