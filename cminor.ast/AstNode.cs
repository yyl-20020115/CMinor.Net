using CMinor.Parser;
using CMinor.Semantic;
using CMinor.Visit;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CMinor.AST;

public abstract class AstNode : DotNode
{
    public class Edge
    {
        public DotNode source;
        public DotNode dest;

        public Edge(DotNode s, DotNode d)
        {
            source = s;
            dest = d;
        }
    }

    private static int numInstances;
    private int instanceNumber;
    private LocationInfo location;

    public virtual void Accept(Visitor v)
    {
        v.Visit(this);
    }
    private void GetNodesAndEdges(ChildVisitor P_0, GetSymbolVisitor P_1, IList P_2, IList P_3, IList P_4, IList P_5)
    {
        P_2.Add(this);
        P_0.Children = new();
        Accept(P_0);
        foreach(AstNode astNode in P_0.Children)
        {
            P_3.Add(new Edge(this, astNode));
            astNode.GetNodesAndEdges(P_0, P_1, P_2, P_3, P_4, P_5);
        }
        var arrayList2 = new List<CMinor.Symbol.Symbol>();
        P_1.Symbols = arrayList2;
        Accept(P_1);
        foreach(CMinor.Symbol.Symbol symbol in arrayList2)
        {
            if (symbol != null)
            {
                P_4.Add(symbol);
                P_5.Add(new Edge(this, symbol));
            }
        }
    }



    public virtual string DotId => ("AstNode") + (instanceNumber);

    protected internal AstNode(LocationInfo location)
    {
        instanceNumber = numInstances++;
        this.location = location;
    }

    public virtual LocationInfo getLocation() => location;



    public virtual string DotLabel
    {
        get
        {
            var dotLabelVisitor = new DotLabelVisitor();
            Accept(dotLabelVisitor);
            return dotLabelVisitor.Label;
        }
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
        GetNodesAndEdges(childVisitor, getSymbolVisitor, arrayList, arrayList2, arrayList3, arrayList4);
        output.WriteLine("digraph {");
        output.WriteLine("\tgraph [ordering=\"out\"];");

        foreach(AstNode astNode in arrayList)
        {
            astNode.Accept(dotLabelVisitor);
            output.WriteLine(("\t") + (astNode.DotId) + (" [label=\"")
                + (dotLabelVisitor.Label)
                + ("\"];")
                );
        }
        foreach(Edge edge in arrayList2)
        {
            output.WriteLine(("\t") + (edge.source.DotId) + (" -> ")
                + (edge.dest.DotId)
                + (";")
                );
        }
        foreach(CMinor.Symbol.Symbol symbol in arrayList3)
        {
            symbol.Accept(symbolDotLabelVisitor);
            output.WriteLine(("\t") + (symbol.DotId) + (" [label=\"")
                + (symbolDotLabelVisitor.Label)
                + ("\", shape=box]")
                );
        }
        foreach(Edge edge in arrayList4)
        {
            output.WriteLine(("\t") + (edge.source.DotId) + (" -> ")
                + (edge.dest.DotId)
                + (" [style=\"dashed\"];")
                );
        }
        output.WriteLine("}");
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
