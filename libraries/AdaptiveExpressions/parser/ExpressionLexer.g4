lexer grammar ExpressionLexer;

@lexer::members {
  bool ignoreWS = true;      // usually we ignore whitespace, but inside stringInterpolation, whitespace is significant
}

fragment LETTER : [a-zA-Z];
fragment DIGIT : [0-9];

STRING_INTERPOLATION_START : '`' { ignoreWS = false;} -> pushMode(STRING_INTERPOLATION_MODE);

// operators
PLUS: '+';

SUBSTRACT: '-';

NON: '!';

XOR: '^';

ASTERISK: '*';

SLASH: '/';

PERCENT: '%';

DOUBLE_EQUAL: '==';

NOT_EQUAL: '!=' | '<>';

SINGLE_AND: '&';

DOUBLE_AND: '&&';

DOUBLE_VERTICAL_CYLINDER: '||';

LESS_THAN: '<';

MORE_THAN: '>';

LESS_OR_EQUAl: '<=';

MORE_OR_EQUAL: '>=';

OPEN_BRACKET: '(';

CLOSE_BRACKET: ')';

DOT: '.';

OPEN_SQUARE_BRACKET: '[';

CLOSE_SQUARE_BRACKET: ']';

COMMA: ',';


NUMBER : DIGIT + ( '.' DIGIT +)? ;

WHITESPACE : (' '|'\t'|'\ufeff'|'\u00a0') {ignoreWS}? -> skip;

IDENTIFIER : (LETTER | '_' | '#' | '@' | '@@' | '$' | '%') (LETTER | DIGIT | '-' | '_')* '!'?;

NEWLINE : '\r'? '\n' -> skip;

STRING : ('\'' (~'\'')* '\'') | ('"' (~'"')* '"');

CONSTANT : ('[' WHITESPACE* ']') | ('{' WHITESPACE* '}');

INVALID_TOKEN_DEFAULT_MODE : . ;

mode STRING_INTERPOLATION_MODE;

STRING_INTERPOLATION_END : '`' {ignoreWS = true;} -> type(STRING_INTERPOLATION_START), popMode;

TEMPLATE : '$' '{' (STRING | ~[\r\n{}'"])*? '}';

ESCAPE_CHARACTER : '\\' ~[\r\n]?;

TEXT_CONTENT :  '\\`' | ~[\r\n];


