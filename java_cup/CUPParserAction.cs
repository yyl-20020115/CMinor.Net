

using JavaCUP.Runtime;
using System;
using System.Collections.Generic;

namespace JavaCUP;


internal class CUP_0024parser_0024actions
{

    protected internal int MAX_RHS;

    protected internal ProductionPart[] rhs_parts;

    protected internal int rhs_pos;

    protected internal string multipart_name;

    protected internal Dictionary<string, SymbolPart> symbols = new();

    protected internal Dictionary<string, NonTerminal> non_terms = new();

    protected internal NonTerminal start_nt;

    protected internal NonTerminal lhs_nt;

    internal int _cur_prec;

    internal int _cur_side;


    private parser parser;



    protected internal virtual void append_multipart(string P_0)
    {
        string str = "";
        if (multipart_name.Length != 0)
        {
            str = ".";
        }
        multipart_name += ((str) + (P_0));
    }




    protected internal virtual void add_rhs_part(ProductionPart P_0)
    {
        if (rhs_pos >= 200)
        {

            throw new Exception("Internal System.Exception: Productions limited to 200 symbols and actions");
        }
        rhs_parts[rhs_pos] = P_0;
        rhs_pos++;
    }




    protected internal virtual ProductionPart add_lab(ProductionPart P_0, string P_1)
    {
        if (P_1 == null || P_0.is_action())
        {
            return P_0;
        }
        SymbolPart result = new SymbolPart(((SymbolPart)P_0).the_symbol(), P_1);

        return result;
    }

    protected internal virtual void new_rhs()
    {
        rhs_pos = 0;
    }


    protected internal virtual void add_precedence(string P_0)
    {
        if (P_0 == null)
        {
            Console.Error.WriteLine("Unable to add precedence to nonexistent terminal");
            return;
        }
        if (!symbols.TryGetValue(P_0, out var symbol_part2))
        {
            Console.Error.WriteLine(("Could find terminal ") + (P_0) + (" while declaring precedence")
                );
            return;
        }
        _Symbol symbol2 = symbol_part2.the_symbol();
        if (symbol2 is Terminal)
        {
            ((Terminal)symbol2).set_precedence(_cur_side, _cur_prec);
        }
        else
        {
            Console.Error.WriteLine(("Precedence declaration: Can't find terminal ") + (P_0));
        }
    }


    protected internal virtual void update_precedence(int P_0)
    {
        _cur_side = P_0;
        _cur_prec++;
    }


    internal CUP_0024parser_0024actions(parser P_0)
    {
        MAX_RHS = 200;
        rhs_parts = new ProductionPart[200];
        rhs_pos = 0;
        multipart_name = "";
        symbols = new();
        non_terms = new();
        start_nt = null;
        _cur_prec = 0;
        _cur_side = -1;
        parser = P_0;
    }


    public Symbol CUP_0024parser_0024do_action(int P_0, LRParser P_1, Stack<Symbol> _P_2, int P_3)
    {
        var P_2 = _P_2.ToArray();
        switch (P_0)
        {
            case 106:

                return new Symbol(29, ((Symbol)P_2[P_3 - 0]).right, ((Symbol)P_2[P_3 - 0]).right, null);
            case 105:

                return new Symbol(7, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 104:

                return new Symbol(7, ((Symbol)P_2[P_3 - 0]).right, ((Symbol)P_2[P_3 - 0]).right, null);
            case 103:

                return new Symbol(8, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 102:

                return new Symbol(8, ((Symbol)P_2[P_3 - 1]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 101:
                {

                    Lexer.emit_error("Illegal use of reserved word");
                    string o2 = "ILLEGAL";
                    return new Symbol(42, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 100:
                {

                    string o2 = "nonassoc";
                    return new Symbol(42, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 99:
                {

                    string o2 = "right";
                    return new Symbol(42, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 98:
                {

                    string o2 = "left";
                    return new Symbol(42, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 97:
                {

                    string o2 = "precedence";
                    return new Symbol(42, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 96:
                {

                    string o2 = "start";
                    return new Symbol(42, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 95:
                {

                    string o2 = "with";
                    return new Symbol(42, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 94:
                {

                    string o2 = "scan";
                    return new Symbol(42, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 93:
                {

                    string o2 = "init";
                    return new Symbol(42, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 92:
                {

                    string o2 = "nonterminal";
                    return new Symbol(42, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 91:
                {

                    string o2 = "non";
                    return new Symbol(42, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 90:
                {

                    string o2 = "terminal";
                    return new Symbol(42, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 89:
                {

                    string o2 = "parser";
                    return new Symbol(42, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 88:
                {

                    string o2 = "action";
                    return new Symbol(42, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 87:
                {

                    string o2 = "code";
                    return new Symbol(42, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 86:
                {

                    _ = ((Symbol)P_2[P_3 - 0]).left;
                    _ = ((Symbol)P_2[P_3 - 0]).right;
                    string text = (string)((Symbol)P_2[P_3 - 0]).value;
                    string o2 = text;
                    return new Symbol(42, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 85:
                {

                    _ = ((Symbol)P_2[P_3 - 0]).left;
                    _ = ((Symbol)P_2[P_3 - 0]).right;
                    string text = (string)((Symbol)P_2[P_3 - 0]).value;
                    string o2 = text;
                    return new Symbol(38, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 84:
                {

                    Lexer.emit_error("Illegal use of reserved word");
                    string o2 = "ILLEGAL";
                    return new Symbol(37, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 83:
                {

                    _ = ((Symbol)P_2[P_3 - 0]).left;
                    _ = ((Symbol)P_2[P_3 - 0]).right;
                    string text = (string)((Symbol)P_2[P_3 - 0]).value;
                    string o2 = text;
                    return new Symbol(37, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 82:
                {

                    Lexer.emit_error("Illegal use of reserved word");
                    string o2 = "ILLEGAL";
                    return new Symbol(36, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 81:
                {

                    _ = ((Symbol)P_2[P_3 - 0]).left;
                    _ = ((Symbol)P_2[P_3 - 0]).right;
                    string text = (string)((Symbol)P_2[P_3 - 0]).value;
                    string o2 = text;
                    return new Symbol(36, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 80:
                {

                    _ = ((Symbol)P_2[P_3 - 0]).left;
                    _ = ((Symbol)P_2[P_3 - 0]).right;
                    string text = (string)((Symbol)P_2[P_3 - 0]).value;
                    if (symbols.ContainsKey(text))
                    {
                        Lexer.emit_error(("java_cup.runtime.Symbol \"") + (text) + ("\" has already been declared")
                            );
                    }
                    else
                    {
                        if (string.Equals(multipart_name, ""))
                        {
                            append_multipart("Object");
                        }
                        NonTerminal value2 = new NonTerminal(text, multipart_name);
                        non_terms.Add(text, value2);
                        symbols.Add(text, new SymbolPart(value2));
                    }
                    return new Symbol(26, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
                }
            case 79:
                {

                    _ = ((Symbol)P_2[P_3 - 0]).left;
                    _ = ((Symbol)P_2[P_3 - 0]).right;
                    string text = (string)((Symbol)P_2[P_3 - 0]).value;
                    if (symbols.ContainsKey(text))
                    {
                        Lexer.emit_error(("java_cup.runtime.Symbol \"") + (text) + ("\" has already been declared")
                    );
                    }
                    else
                    {
                        if (string.Equals(multipart_name, ""))
                        {
                            append_multipart("Object");
                        }
                        var hashtable = symbols;
                        string key = text;
                        hashtable.Add(key, new SymbolPart(new Terminal(text, multipart_name)));
                    }
                    return new Symbol(25, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
                }
            case 78:

                multipart_name += "[]";
                return new Symbol(19, ((Symbol)P_2[P_3 - 2]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 77:

                return new Symbol(19, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 76:

                return new Symbol(15, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 75:

                append_multipart("*");
                return new Symbol(15, ((Symbol)P_2[P_3 - 2]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 74:
                {

                    _ = ((Symbol)P_2[P_3 - 0]).left;
                    _ = ((Symbol)P_2[P_3 - 0]).right;
                    string text = (string)((Symbol)P_2[P_3 - 0]).value;
                    append_multipart(text);
                    return new Symbol(13, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
                }
            case 73:
                {

                    _ = ((Symbol)P_2[P_3 - 0]).left;
                    _ = ((Symbol)P_2[P_3 - 0]).right;
                    string text = (string)((Symbol)P_2[P_3 - 0]).value;
                    append_multipart(text);
                    return new Symbol(13, ((Symbol)P_2[P_3 - 2]).left, ((Symbol)P_2[P_3 - 0]).right, null);
                }
            case 72:


                return new Symbol(39, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 71:
                {

                    _ = ((Symbol)P_2[P_3 - 0]).left;
                    _ = ((Symbol)P_2[P_3 - 0]).right;
                    string text = (string)((Symbol)P_2[P_3 - 0]).value;
                    string o2 = text;
                    return new Symbol(39, ((Symbol)P_2[P_3 - 1]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 70:
                {

                    _ = ((Symbol)P_2[P_3 - 0]).left;
                    _ = ((Symbol)P_2[P_3 - 0]).right;
                    string text = (string)((Symbol)P_2[P_3 - 0]).value;
                    add_rhs_part(new ActionPart(text));
                    return new Symbol(24, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
                }
            case 69:
                {

                    _ = ((Symbol)P_2[P_3 - 1]).left;
                    _ = ((Symbol)P_2[P_3 - 1]).right;
                    string text = (string)((Symbol)P_2[P_3 - 1]).value;
                    _ = ((Symbol)P_2[P_3 - 0]).left;
                    _ = ((Symbol)P_2[P_3 - 0]).right;
                    string text2 = (string)((Symbol)P_2[P_3 - 0]).value;
                    if (!symbols.TryGetValue(text, out var production_part2))
                    {
                        if (Lexer.error_count == 0)
                        {
                            Lexer.emit_error(("java_cup.runtime.Symbol \"") + (text) + ("\" has not been declared")
                                );
                        }
                    }
                    else
                    {
                        add_rhs_part(add_lab(production_part2, text2));
                    }
                    return new Symbol(24, ((Symbol)P_2[P_3 - 1]).left, ((Symbol)P_2[P_3 - 0]).right, null);
                }
            case 68:

                return new Symbol(23, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 67:

                return new Symbol(23, ((Symbol)P_2[P_3 - 1]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 66:

                if (lhs_nt != null)
                {

                    new Production(lhs_nt, rhs_parts, rhs_pos);
                    if (start_nt == null)
                    {
                        start_nt = lhs_nt;
                        new_rhs();
                        add_rhs_part(add_lab(new SymbolPart(start_nt), "start_val"));
                        add_rhs_part(new SymbolPart(Terminal.___003C_003EEOF));
                        add_rhs_part(new ActionPart("RESULT = start_val;"));

                        emit.start_production = new Production(NonTerminal._START_SYMBOL, rhs_parts, rhs_pos);
                        new_rhs();
                    }
                }
                new_rhs();
                return new Symbol(28, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 65:
                {

                    _ = ((Symbol)P_2[P_3 - 0]).left;
                    _ = ((Symbol)P_2[P_3 - 0]).right;
                    string text = (string)((Symbol)P_2[P_3 - 0]).value;

                    if (lhs_nt != null)
                    {
                        _Symbol symbol2 = null;
                        if (text == null)
                        {
                            Console.Error.WriteLine("No terminal for contextual precedence");
                            symbol2 = null;
                        }
                        else
                        {
                            //					symbol2 = ((SymbolPart)symbols.Get(text)).the_symbol();
                            symbols.TryGetValue(text, out symbol2);
                        }
                        if (symbol2 != null && symbol2 is Terminal t)
                        {

                            new Production(lhs_nt, rhs_parts, rhs_pos, ((Terminal)symbol2).precedence_num(), ((Terminal)symbol2).precedence_side());
                            symbols.TryGetValue(text, out symbol2);
                            ((SymbolPart)symbols.Get(text)).the_symbol().NoteUse();
                        }
                        else
                        {
                            Console.Error.WriteLine(("Invalid terminal ") + (text) + (" for contextual precedence assignment")
                                );

                            new Production(lhs_nt, rhs_parts, rhs_pos);
                        }
                        if (start_nt == null)
                        {
                            start_nt = lhs_nt;
                            new_rhs();
                            add_rhs_part(add_lab(new SymbolPart(start_nt), "start_val"));
                            add_rhs_part(new SymbolPart(Terminal.___003C_003EEOF));
                            add_rhs_part(new ActionPart("RESULT = start_val;"));
                            if (symbol2 != null && symbol2 is Terminal)
                            {

                                emit.start_production = new Production(NonTerminal._START_SYMBOL, rhs_parts, rhs_pos, ((Terminal)symbol2).precedence_num(), ((Terminal)symbol2).precedence_side());
                            }
                            else
                            {

                                emit.start_production = new Production(NonTerminal._START_SYMBOL, rhs_parts, rhs_pos);
                            }
                            new_rhs();
                        }
                    }
                    new_rhs();
                    return new Symbol(28, ((Symbol)P_2[P_3 - 2]).left, ((Symbol)P_2[P_3 - 0]).right, null);
                }
            case 64:

                return new Symbol(27, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 63:

                return new Symbol(27, ((Symbol)P_2[P_3 - 2]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 62:
                {
                    object o = null;
                    if (((Symbol)P_2[P_3 - 1]).value != null)
                    {
                        o = ((Symbol)P_2[P_3 - 1]).value;
                    }
                    return new Symbol(22, ((Symbol)P_2[P_3 - 2]).left, ((Symbol)P_2[P_3 - 0]).right, o);
                }
            case 61:

                Lexer.emit_error("Syntax System.Exception");
                return new Symbol(56, ((Symbol)P_2[P_3 - 0]).right, ((Symbol)P_2[P_3 - 0]).right, null);
            case 60:
                {
                    object o = null;
                    if (((Symbol)P_2[P_3 - 4]).value != null)
                    {
                        o = ((Symbol)P_2[P_3 - 4]).value;
                    }
                    if (((Symbol)P_2[P_3 - 2]).value != null)
                    {
                        o = ((Symbol)P_2[P_3 - 2]).value;
                    }
                    _ = ((Symbol)P_2[P_3 - 5]).left;
                    _ = ((Symbol)P_2[P_3 - 5]).right;
                    _ = (string)((Symbol)P_2[P_3 - 5]).value;
                    return new Symbol(22, ((Symbol)P_2[P_3 - 5]).left, ((Symbol)P_2[P_3 - 0]).right, o);
                }
            case 59:

                _ = ((Symbol)P_2[P_3 - 2]).left;
                _ = ((Symbol)P_2[P_3 - 2]).right;
                _ = (string)((Symbol)P_2[P_3 - 2]).value;
                return new Symbol(55, ((Symbol)P_2[P_3 - 0]).right, ((Symbol)P_2[P_3 - 0]).right, null);
            case 58:
                {

                    _ = ((Symbol)P_2[P_3 - 0]).left;
                    _ = ((Symbol)P_2[P_3 - 0]).right;
                    string text = (string)((Symbol)P_2[P_3 - 0]).value;
                    if (!non_terms.TryGetValue(text, out lhs_nt) && Lexer.error_count == 0)
                    {
                        Lexer.emit_error(("LHS non terminal \"") + (text) + ("\" has not been declared")
                            );
                    }
                    new_rhs();
                    return new Symbol(54, ((Symbol)P_2[P_3 - 0]).right, ((Symbol)P_2[P_3 - 0]).right, null);
                }
            case 57:

                return new Symbol(12, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 56:

                return new Symbol(12, ((Symbol)P_2[P_3 - 1]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 55:

                return new Symbol(11, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 54:
                {
                    object o = null;
                    if (((Symbol)P_2[P_3 - 1]).value != null)
                    {
                        o = ((Symbol)P_2[P_3 - 1]).value;
                    }
                    _ = ((Symbol)P_2[P_3 - 2]).left;
                    _ = ((Symbol)P_2[P_3 - 2]).right;
                    _ = (string)((Symbol)P_2[P_3 - 2]).value;
                    return new Symbol(11, ((Symbol)P_2[P_3 - 4]).left, ((Symbol)P_2[P_3 - 0]).right, o);
                }
            case 53:
                {

                    _ = ((Symbol)P_2[P_3 - 0]).left;
                    _ = ((Symbol)P_2[P_3 - 0]).right;
                    string text = (string)((Symbol)P_2[P_3 - 0]).value;
                    if (!non_terms.TryGetValue(text,out var value2))
                    {
                        Lexer.emit_error(("Start non terminal \"") + (text) + ("\" has not been declared")
                            );
                    }
                    else
                    {
                        start_nt = value2;
                        new_rhs();
                        add_rhs_part(add_lab(new SymbolPart(start_nt), "start_val"));
                        add_rhs_part(new SymbolPart(Terminal.___003C_003EEOF));
                        add_rhs_part(new ActionPart("RESULT = start_val;"));

                        emit.start_production = new Production(NonTerminal._START_SYMBOL, rhs_parts, rhs_pos);
                        new_rhs();
                    }
                    return new Symbol(53, ((Symbol)P_2[P_3 - 0]).right, ((Symbol)P_2[P_3 - 0]).right, null);
                }
            case 52:
                {

                    _ = ((Symbol)P_2[P_3 - 0]).left;
                    _ = ((Symbol)P_2[P_3 - 0]).right;
                    string text = (string)((Symbol)P_2[P_3 - 0]).value;
                    if (!symbols.ContainsKey(text))
                    {
                        Lexer.emit_error(("Terminal \"") + (text) + ("\" has not been declared")
                            );
                    }
                    string o2 = text;
                    return new Symbol(41, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 51:
                {

                    _ = ((Symbol)P_2[P_3 - 0]).left;
                    _ = ((Symbol)P_2[P_3 - 0]).right;
                    string text = (string)((Symbol)P_2[P_3 - 0]).value;
                    add_precedence(text);
                    string o2 = text;
                    return new Symbol(40, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, o2);
                }
            case 50:

                return new Symbol(32, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 49:

                return new Symbol(32, ((Symbol)P_2[P_3 - 2]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 48:
                {
                    object o = null;
                    if (((Symbol)P_2[P_3 - 2]).value != null)
                    {
                        o = ((Symbol)P_2[P_3 - 2]).value;
                    }
                    return new Symbol(31, ((Symbol)P_2[P_3 - 4]).left, ((Symbol)P_2[P_3 - 0]).right, o);
                }
            case 47:

                update_precedence(2);
                return new Symbol(52, ((Symbol)P_2[P_3 - 0]).right, ((Symbol)P_2[P_3 - 0]).right, null);
            case 46:
                {
                    object o = null;
                    if (((Symbol)P_2[P_3 - 2]).value != null)
                    {
                        o = ((Symbol)P_2[P_3 - 2]).value;
                    }
                    return new Symbol(31, ((Symbol)P_2[P_3 - 4]).left, ((Symbol)P_2[P_3 - 0]).right, o);
                }
            case 45:

                update_precedence(1);
                return new Symbol(51, ((Symbol)P_2[P_3 - 0]).right, ((Symbol)P_2[P_3 - 0]).right, null);
            case 44:
                {
                    object o = null;
                    if (((Symbol)P_2[P_3 - 2]).value != null)
                    {
                        o = ((Symbol)P_2[P_3 - 2]).value;
                    }
                    return new Symbol(31, ((Symbol)P_2[P_3 - 4]).left, ((Symbol)P_2[P_3 - 0]).right, o);
                }
            case 43:

                update_precedence(0);
                return new Symbol(50, ((Symbol)P_2[P_3 - 0]).right, ((Symbol)P_2[P_3 - 0]).right, null);
            case 42:

                return new Symbol(33, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 41:

                return new Symbol(33, ((Symbol)P_2[P_3 - 1]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 40:

                return new Symbol(30, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 39:

                return new Symbol(30, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 38:

                return new Symbol(21, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 37:

                return new Symbol(21, ((Symbol)P_2[P_3 - 2]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 36:

                return new Symbol(20, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 35:

                return new Symbol(20, ((Symbol)P_2[P_3 - 2]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 34:
                {
                    object o = null;
                    if (((Symbol)P_2[P_3 - 1]).value != null)
                    {
                        o = ((Symbol)P_2[P_3 - 1]).value;
                    }
                    return new Symbol(35, ((Symbol)P_2[P_3 - 2]).left, ((Symbol)P_2[P_3 - 0]).right, o);
                }
            case 33:

                multipart_name = "";
                return new Symbol(49, ((Symbol)P_2[P_3 - 0]).right, ((Symbol)P_2[P_3 - 0]).right, null);
            case 32:
                {
                    object o = null;
                    if (((Symbol)P_2[P_3 - 1]).value != null)
                    {
                        o = ((Symbol)P_2[P_3 - 1]).value;
                    }
                    return new Symbol(34, ((Symbol)P_2[P_3 - 2]).left, ((Symbol)P_2[P_3 - 0]).right, o);
                }
            case 31:

                multipart_name = "";
                return new Symbol(48, ((Symbol)P_2[P_3 - 0]).right, ((Symbol)P_2[P_3 - 0]).right, null);
            case 30:
                {
                    object o = null;
                    if (((Symbol)P_2[P_3 - 1]).value != null)
                    {
                        o = ((Symbol)P_2[P_3 - 1]).value;
                    }
                    return new Symbol(18, ((Symbol)P_2[P_3 - 3]).left, ((Symbol)P_2[P_3 - 0]).right, o);
                }
            case 29:

                multipart_name = "";
                return new Symbol(47, ((Symbol)P_2[P_3 - 0]).right, ((Symbol)P_2[P_3 - 0]).right, null);
            case 28:
                {
                    object o = null;
                    if (((Symbol)P_2[P_3 - 1]).value != null)
                    {
                        o = ((Symbol)P_2[P_3 - 1]).value;
                    }
                    return new Symbol(18, ((Symbol)P_2[P_3 - 3]).left, ((Symbol)P_2[P_3 - 0]).right, o);
                }
            case 27:

                multipart_name = "";
                return new Symbol(46, ((Symbol)P_2[P_3 - 0]).right, ((Symbol)P_2[P_3 - 0]).right, null);
            case 26:

                return new Symbol(18, ((Symbol)P_2[P_3 - 1]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 25:

                return new Symbol(18, ((Symbol)P_2[P_3 - 2]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 24:

                return new Symbol(18, ((Symbol)P_2[P_3 - 1]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 23:

                return new Symbol(18, ((Symbol)P_2[P_3 - 2]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 22:

                return new Symbol(10, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 21:

                return new Symbol(10, ((Symbol)P_2[P_3 - 1]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 20:
                {

                    _ = ((Symbol)P_2[P_3 - 1]).left;
                    _ = ((Symbol)P_2[P_3 - 1]).right;
                    string text = (string)((Symbol)P_2[P_3 - 1]).value;
                    if (emit.scan_code != null)
                    {
                        Lexer.emit_error("Redundant scan code (skipping)");
                    }
                    else
                    {
                        emit.scan_code = text;
                    }
                    return new Symbol(17, ((Symbol)P_2[P_3 - 3]).left, ((Symbol)P_2[P_3 - 0]).right, null);
                }
            case 19:
                {

                    _ = ((Symbol)P_2[P_3 - 1]).left;
                    _ = ((Symbol)P_2[P_3 - 1]).right;
                    string text = (string)((Symbol)P_2[P_3 - 1]).value;
                    if (emit.init_code != null)
                    {
                        Lexer.emit_error("Redundant init code (skipping)");
                    }
                    else
                    {
                        emit.init_code = text;
                    }
                    return new Symbol(16, ((Symbol)P_2[P_3 - 3]).left, ((Symbol)P_2[P_3 - 0]).right, null);
                }
            case 18:
                {

                    _ = ((Symbol)P_2[P_3 - 1]).left;
                    _ = ((Symbol)P_2[P_3 - 1]).right;
                    string text = (string)((Symbol)P_2[P_3 - 1]).value;
                    if (emit.parser_code != null)
                    {
                        Lexer.emit_error("Redundant parser code (skipping)");
                    }
                    else
                    {
                        emit.parser_code = text;
                    }
                    return new Symbol(9, ((Symbol)P_2[P_3 - 3]).left, ((Symbol)P_2[P_3 - 0]).right, null);
                }
            case 17:
                {

                    _ = ((Symbol)P_2[P_3 - 1]).left;
                    _ = ((Symbol)P_2[P_3 - 1]).right;
                    string text = (string)((Symbol)P_2[P_3 - 1]).value;
                    if (emit.action_code != null)
                    {
                        Lexer.emit_error("Redundant action code (skipping)");
                    }
                    else
                    {
                        emit.action_code = text;
                    }
                    return new Symbol(4, ((Symbol)P_2[P_3 - 3]).left, ((Symbol)P_2[P_3 - 0]).right, null);
                }
            case 16:

                return new Symbol(5, ((Symbol)P_2[P_3 - 1]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 15:

                return new Symbol(5, ((Symbol)P_2[P_3 - 0]).right, ((Symbol)P_2[P_3 - 0]).right, null);
            case 14:

                return new Symbol(6, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 13:

                return new Symbol(6, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 12:

                return new Symbol(6, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 11:

                return new Symbol(6, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 10:
                {
                    object o = null;
                    if (((Symbol)P_2[P_3 - 1]).value != null)
                    {
                        o = ((Symbol)P_2[P_3 - 1]).value;
                    }
                    return new Symbol(14, ((Symbol)P_2[P_3 - 3]).left, ((Symbol)P_2[P_3 - 0]).right, o);
                }
            case 9:

                emit.import_list.Push(multipart_name);
                multipart_name = "";
                return new Symbol(45, ((Symbol)P_2[P_3 - 0]).right, ((Symbol)P_2[P_3 - 0]).right, null);
            case 8:

                return new Symbol(3, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 7:

                return new Symbol(3, ((Symbol)P_2[P_3 - 1]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 6:

                return new Symbol(2, ((Symbol)P_2[P_3 - 0]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 5:
                {
                    object o = null;
                    if (((Symbol)P_2[P_3 - 1]).value != null)
                    {
                        o = ((Symbol)P_2[P_3 - 1]).value;
                    }
                    return new Symbol(2, ((Symbol)P_2[P_3 - 3]).left, ((Symbol)P_2[P_3 - 0]).right, o);
                }
            case 4:

                emit.package_name = multipart_name;
                multipart_name = "";
                return new Symbol(44, ((Symbol)P_2[P_3 - 0]).right, ((Symbol)P_2[P_3 - 0]).right, null);
            case 3:

                return new Symbol(1, ((Symbol)P_2[P_3 - 4]).left, ((Symbol)P_2[P_3 - 0]).right, null);
            case 2:
                {
                    object o = null;
                    if (((Symbol)P_2[P_3 - 7]).value != null)
                    {
                        o = ((Symbol)P_2[P_3 - 7]).value;
                    }
                    return new Symbol(1, ((Symbol)P_2[P_3 - 7]).left, ((Symbol)P_2[P_3 - 0]).right, o);
                }
            case 1:

                symbols.Add("error", new SymbolPart(Terminal.___003C_003Eerror));
                non_terms.Add("$START", NonTerminal._START_SYMBOL);
                return new Symbol(43, ((Symbol)P_2[P_3 - 0]).right, ((Symbol)P_2[P_3 - 0]).right, null);
            case 0:
                {

                    _ = ((Symbol)P_2[P_3 - 1]).left;
                    _ = ((Symbol)P_2[P_3 - 1]).right;
                    object value = ((Symbol)P_2[P_3 - 1]).value;
                    object o = value;
                    Symbol result = new Symbol(0, ((Symbol)P_2[P_3 - 1]).left, ((Symbol)P_2[P_3 - 0]).right, o);
                    P_1.done_parsing();
                    return result;
                }
            default:

                throw new Exception("Invalid action number found in internal parse table");
        }
    }
}
