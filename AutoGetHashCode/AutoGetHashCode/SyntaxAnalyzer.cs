using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AutoGetHashCode
{
    public class SyntaxAnalyzer
    {
        public static IEnumerable<ClassDeclarationSyntax> GetAttributedClasses(SyntaxTree syntaxTree)
        {
            return syntaxTree.GetRoot().DescendantNodes()
                .OfType<AttributeSyntax>()
                .Where(attribute => attribute.Name.ToString().Equals("AutoGetHashCode"))
                .Select(attribute => attribute.Parent.Parent)
                .Cast<ClassDeclarationSyntax>();
        }

        public static bool IsClassPartial(ClassDeclarationSyntax classDeclaration)
        {
            return classDeclaration.Modifiers.Any(SyntaxKind.PartialKeyword);
        }

        public static bool IsOverridingEquals(ClassDeclarationSyntax classDeclaration)
        {
            return IsOverridingMethod(classDeclaration, "Equals");
        }

        public static bool IsOverridingGetHashCode(ClassDeclarationSyntax classDeclaration)
        {
            return IsOverridingMethod(classDeclaration, "GetHashCode");
        }

        private static bool IsOverridingMethod(ClassDeclarationSyntax classDeclaration, string identifierName)
        {
            var methodDeclarations =
                classDeclaration.DescendantNodes()
                    .Where(node => node.IsKind(SyntaxKind.MethodDeclaration))
                    .Cast<MethodDeclarationSyntax>();
            var publicOverrideMethods = methodDeclarations.Where(node => node.Modifiers.Any(SyntaxKind.OverrideKeyword)
                                                                         && node.Modifiers.Any(SyntaxKind.PublicKeyword));
            return publicOverrideMethods.Any(node => node.Identifier.Text == identifierName);
        }

        public static string GetNamespace(SyntaxTree syntaxTree)
        {
            return syntaxTree.GetRoot().DescendantNodes()
                .Where(node => node.IsKind(SyntaxKind.NamespaceDeclaration))
                .Cast<NamespaceDeclarationSyntax>()
                .First()
                .Name.ToString();
        }

        public static string GetClassName(ClassDeclarationSyntax classDeclarationSyntax)
        {
            return classDeclarationSyntax.Identifier.Text;
        }

        public static IEnumerable<FieldDeclarationSyntax> GetFields(SyntaxTree syntaxTree)
        {
            var result = syntaxTree.GetRoot().DescendantNodes()
                .Where(node => node.IsKind(SyntaxKind.FieldDeclaration))
                .Cast<FieldDeclarationSyntax>();
            return result;
        }

        public static IEnumerable<PropertyDeclarationSyntax> GetProperties(SyntaxTree syntaxTree)
        {
            var result = syntaxTree.GetRoot().DescendantNodes()
                .Where(node => node.IsKind(SyntaxKind.PropertyDeclaration))
                .Cast<PropertyDeclarationSyntax>();
            return result;
        } 
    }
}