using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;

namespace AutoGetHashCode
{
    public class ClassGenerator
    {
        public static void GenerateClass(string namespaceName, string className, SyntaxTree syntaxTree)
        {
            var attributeList = new SyntaxList<AttributeListSyntax>();
            var modifiers = new SyntaxTokenList()
                .Add(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .Add(SyntaxFactory.Token(SyntaxKind.OverrideKeyword));
            var returnType = SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.IntKeyword));
            var identifier = SyntaxFactory.Identifier("ToHashCode");
            var typeParameterListSyntax = SyntaxFactory.TypeParameterList();
            var parameterList = SyntaxFactory.ParameterList();
            var typeParameterConstraints = new SyntaxList<TypeParameterConstraintClauseSyntax>();
            var block = GenerateBlock(syntaxTree);
            var semicolonToken = SyntaxFactory.Token(SyntaxKind.SemicolonToken);
            var methodDecl = SyntaxFactory.MethodDeclaration(
                attributeLists: attributeList, 
                modifiers: modifiers,
                returnType: returnType, 
                explicitInterfaceSpecifier: null, 
                identifier: identifier,
                typeParameterList: null, 
                parameterList: parameterList, 
                constraintClauses: typeParameterConstraints,
                body: block, semicolonToken: semicolonToken);

            CompilationUnitSyntax compilationUnit = SyntaxFactory.CompilationUnit()
                .AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.IdentifierName("System")))
                .AddMembers(SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName(namespaceName))
                    .AddMembers(SyntaxFactory.ClassDeclaration(className)
                        .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                            SyntaxFactory.Token(SyntaxKind.PartialKeyword))
                        .AddMembers(methodDecl)));

            SyntaxNode formattedNode = Formatter.Format(compilationUnit, new AdhocWorkspace());
            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
            {
                formattedNode.WriteTo(writer);
                Console.WriteLine(  );
            }

        }

        private static BlockSyntax GenerateBlock(SyntaxTree syntaxTree)
        {
            var block = SyntaxFactory.Block();
            var fields = SyntaxAnalyzer.GetFields(syntaxTree);
            var properties = SyntaxAnalyzer.GetProperties(syntaxTree);

            return SyntaxFactory.Block();
        }
    }
}
