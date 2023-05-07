
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF         =  0, // (EOF)
        SYMBOL_ERROR       =  1, // (Error)
        SYMBOL_WHITESPACE  =  2, // Whitespace
        SYMBOL_MINUS       =  3, // '-'
        SYMBOL_MINUSMINUS  =  4, // '--'
        SYMBOL_EXCLAMEQ    =  5, // '!='
        SYMBOL_PERCENT     =  6, // '%'
        SYMBOL_LPAREN      =  7, // '('
        SYMBOL_RPAREN      =  8, // ')'
        SYMBOL_TIMES       =  9, // '*'
        SYMBOL_DIV         = 10, // '/'
        SYMBOL_COLON       = 11, // ':'
        SYMBOL_SEMI        = 12, // ';'
        SYMBOL_LBRACE      = 13, // '{'
        SYMBOL_RBRACE      = 14, // '}'
        SYMBOL_PLUS        = 15, // '+'
        SYMBOL_PLUSPLUS    = 16, // '++'
        SYMBOL_LT          = 17, // '<'
        SYMBOL_EQ          = 18, // '='
        SYMBOL_EQEQ        = 19, // '=='
        SYMBOL_GT          = 20, // '>'
        SYMBOL_BREAK       = 21, // break
        SYMBOL_CASE        = 22, // case
        SYMBOL_DIGIT       = 23, // Digit
        SYMBOL_DOUBLE      = 24, // double
        SYMBOL_ELSE        = 25, // else
        SYMBOL_END         = 26, // End
        SYMBOL_FLOAT       = 27, // float
        SYMBOL_FOR         = 28, // for
        SYMBOL_ID          = 29, // Id
        SYMBOL_IF          = 30, // if
        SYMBOL_INT         = 31, // int
        SYMBOL_START       = 32, // Start
        SYMBOL_STRING      = 33, // string
        SYMBOL_SWITCH      = 34, // switch
        SYMBOL_ASSIGN      = 35, // <assign>
        SYMBOL_BREAK_STMT  = 36, // <break_stmt>
        SYMBOL_CASE2       = 37, // <case>
        SYMBOL_CASE_LIST   = 38, // <case_list>
        SYMBOL_CONCEPT     = 39, // <concept>
        SYMBOL_COND        = 40, // <cond>
        SYMBOL_DATA        = 41, // <data>
        SYMBOL_DIGIT2      = 42, // <digit>
        SYMBOL_EXPR        = 43, // <expr>
        SYMBOL_FACTOR      = 44, // <factor>
        SYMBOL_FOR_STAT    = 45, // <for_stat>
        SYMBOL_ID2         = 46, // <id>
        SYMBOL_IF_STAT     = 47, // <if_stat>
        SYMBOL_OP          = 48, // <op>
        SYMBOL_PROGRAM     = 49, // <program>
        SYMBOL_STAT_LIST   = 50, // <stat_list>
        SYMBOL_STEP        = 51, // <step>
        SYMBOL_SWITCH_STMT = 52, // <switch_stmt>
        SYMBOL_TERM        = 53, // <term>
        SYMBOL_VALUE       = 54  // <value>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_START_END                                 =  0, // <program> ::= Start <stat_list> End
        RULE_STAT_LIST                                         =  1, // <stat_list> ::= <concept>
        RULE_STAT_LIST2                                        =  2, // <stat_list> ::= <concept> <stat_list>
        RULE_CONCEPT                                           =  3, // <concept> ::= <assign>
        RULE_CONCEPT2                                          =  4, // <concept> ::= <if_stat>
        RULE_CONCEPT3                                          =  5, // <concept> ::= <for_stat>
        RULE_CONCEPT4                                          =  6, // <concept> ::= <switch_stmt>
        RULE_ASSIGN_EQ_SEMI                                    =  7, // <assign> ::= <id> '=' <expr> ';'
        RULE_ID_ID                                             =  8, // <id> ::= Id
        RULE_EXPR                                              =  9, // <expr> ::= <term>
        RULE_EXPR_PLUS                                         = 10, // <expr> ::= <term> '+' <expr>
        RULE_EXPR_MINUS                                        = 11, // <expr> ::= <term> '-' <expr>
        RULE_TERM                                              = 12, // <term> ::= <factor>
        RULE_TERM_TIMES                                        = 13, // <term> ::= <factor> '*' <term>
        RULE_TERM_DIV                                          = 14, // <term> ::= <factor> '/' <term>
        RULE_TERM_PERCENT                                      = 15, // <term> ::= <factor> '%' <term>
        RULE_FACTOR_PLUSPLUS                                   = 16, // <factor> ::= <value> '++'
        RULE_FACTOR_MINUSMINUS                                 = 17, // <factor> ::= '--' <id>
        RULE_FACTOR                                            = 18, // <factor> ::= <value>
        RULE_VALUE_LPAREN_RPAREN                               = 19, // <value> ::= '(' <expr> ')'
        RULE_VALUE                                             = 20, // <value> ::= <id>
        RULE_VALUE2                                            = 21, // <value> ::= <digit>
        RULE_DIGIT_DIGIT                                       = 22, // <digit> ::= Digit
        RULE_IF_STAT_IF_LPAREN_RPAREN_START_END                = 23, // <if_stat> ::= if '(' <cond> ')' Start <stat_list> End
        RULE_IF_STAT_IF_LPAREN_RPAREN_START_END_ELSE_START_END = 24, // <if_stat> ::= if '(' <cond> ')' Start <stat_list> End else Start <stat_list> End
        RULE_COND                                              = 25, // <cond> ::= <expr> <op> <expr>
        RULE_OP_LT                                             = 26, // <op> ::= '<'
        RULE_OP_GT                                             = 27, // <op> ::= '>'
        RULE_OP_EQEQ                                           = 28, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                                       = 29, // <op> ::= '!='
        RULE_FOR_STAT_FOR_LPAREN_SEMI_RPAREN_LBRACE_RBRACE     = 30, // <for_stat> ::= for '(' <assign> <cond> ';' <step> ')' '{' <stat_list> '}'
        RULE_DATA_INT                                          = 31, // <data> ::= int
        RULE_DATA_FLOAT                                        = 32, // <data> ::= float
        RULE_DATA_DOUBLE                                       = 33, // <data> ::= double
        RULE_DATA_STRING                                       = 34, // <data> ::= string
        RULE_STEP_MINUSMINUS                                   = 35, // <step> ::= '--' <id>
        RULE_STEP_MINUSMINUS2                                  = 36, // <step> ::= <id> '--'
        RULE_STEP_PLUSPLUS                                     = 37, // <step> ::= '++' <id>
        RULE_STEP_PLUSPLUS2                                    = 38, // <step> ::= <id> '++'
        RULE_SWITCH_STMT_SWITCH_LPAREN_RPAREN_LBRACE_RBRACE    = 39, // <switch_stmt> ::= switch '(' <expr> ')' '{' <case_list> '}'
        RULE_CASE_LIST                                         = 40, // <case_list> ::= <case>
        RULE_CASE_LIST2                                        = 41, // <case_list> ::= <case> <case_list>
        RULE_CASE_CASE_COLON                                   = 42, // <case> ::= case <expr> ':' <stat_list> <break_stmt>
        RULE_BREAK_STMT_BREAK_SEMI                             = 43  // <break_stmt> ::= break ';'
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox lst;
        public MyParser(string filename,ListBox lst)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            this.lst = lst;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BREAK :
                //break
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //End
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_START :
                //Start
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //switch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BREAK_STMT :
                //<break_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE2 :
                //<case>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE_LIST :
                //<case_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONCEPT :
                //<concept>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DATA :
                //<data>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_STAT :
                //<for_stat>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STAT :
                //<if_stat>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STAT_LIST :
                //<stat_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP :
                //<step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH_STMT :
                //<switch_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALUE :
                //<value>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_START_END :
                //<program> ::= Start <stat_list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STAT_LIST :
                //<stat_list> ::= <concept>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STAT_LIST2 :
                //<stat_list> ::= <concept> <stat_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT :
                //<concept> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT2 :
                //<concept> ::= <if_stat>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT3 :
                //<concept> ::= <for_stat>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT4 :
                //<concept> ::= <switch_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ_SEMI :
                //<assign> ::= <id> '=' <expr> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <term> '+' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <term> '-' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <factor> '*' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <factor> '/' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<term> ::= <factor> '%' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_PLUSPLUS :
                //<factor> ::= <value> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_MINUSMINUS :
                //<factor> ::= '--' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_LPAREN_RPAREN :
                //<value> ::= '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE :
                //<value> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE2 :
                //<value> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<digit> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STAT_IF_LPAREN_RPAREN_START_END :
                //<if_stat> ::= if '(' <cond> ')' Start <stat_list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STAT_IF_LPAREN_RPAREN_START_END_ELSE_START_END :
                //<if_stat> ::= if '(' <cond> ')' Start <stat_list> End else Start <stat_list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<cond> ::= <expr> <op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STAT_FOR_LPAREN_SEMI_RPAREN_LBRACE_RBRACE :
                //<for_stat> ::= for '(' <assign> <cond> ';' <step> ')' '{' <stat_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_INT :
                //<data> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_FLOAT :
                //<data> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_DOUBLE :
                //<data> ::= double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_STRING :
                //<data> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS :
                //<step> ::= '--' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS2 :
                //<step> ::= <id> '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS :
                //<step> ::= '++' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS2 :
                //<step> ::= <id> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCH_STMT_SWITCH_LPAREN_RPAREN_LBRACE_RBRACE :
                //<switch_stmt> ::= switch '(' <expr> ')' '{' <case_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_LIST :
                //<case_list> ::= <case>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_LIST2 :
                //<case_list> ::= <case> <case_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_CASE_COLON :
                //<case> ::= case <expr> ':' <stat_list> <break_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BREAK_STMT_BREAK_SEMI :
                //<break_stmt> ::= break ';'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+" in Line : "+args.UnexpectedToken.Location.LineNr;
            lst.Items.Add(message);
            string m2 = "Expected Token "+args.ExpectedTokens.ToString();
            lst.Items.Add(m2);
            //todo: Report message to UI?
        }

    }
}
