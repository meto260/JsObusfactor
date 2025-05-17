using JsObusfactor.Strategies;
using NUglify;
using NUglify.JavaScript;

namespace JsObusfactor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check command line parameters
            if (args.Length == 0)
            {
                Console.WriteLine("Please specify a JavaScript file path.");
                Console.WriteLine("Usage: JsObusfactor <js_file_path> [output_file_path]");
                Console.WriteLine("Example: JsObusfactor input.js output.js");
                Console.Read();
                return;
            }

            string jsFilePath = args[0];
            string outputFilePath = null;

            // If second parameter exists, set it as output file path
            if (args.Length > 1)
            {
                outputFilePath = args[1];
            }

            // Check if file exists
            if (!File.Exists(jsFilePath))
            {
                Console.WriteLine($"Error: File {jsFilePath} not found.");
                Console.Read();
                return;
            }

            try
            {
                // Read JavaScript file
                string jsContent = File.ReadAllText(jsFilePath);
                
                // First stage: Basic obfuscation with NUglify
                var uglifySettings = new CodeSettings
                {
                    MinifyCode = true,
                    LocalRenaming = LocalRenaming.CrunchAll,
                    EvalTreatment = EvalTreatment.MakeImmediateSafe,
                    PreserveImportantComments = false,
                    ManualRenamesProperties = true,
                    RemoveUnneededCode = true,
                    StripDebugStatements = true,
                    TermSemicolons = true,
                    ReorderScopeDeclarations = true,
                    // Advanced settings
                    RemoveFunctionExpressionNames = true,
                    ConstStatementsMozilla = true,
                    InlineSafeStrings = true,
                    MacSafariQuirks = true,
                    CollapseToLiteral = true,
                };
                
                var uglifyResult = Uglify.Js(jsContent, uglifySettings);
                
                if (uglifyResult.HasErrors)
                {
                    Console.WriteLine("Errors occurred during obfuscation:");
                    foreach (var error in uglifyResult.Errors)
                    {
                        Console.WriteLine($"- {error}");
                    }
                    Console.Read();
                    return;
                }
                
                // Second stage: Advanced obfuscation using Strategy pattern
                string obfuscatedCode = ApplyObfuscationStrategies(uglifyResult.Code);
                
                // Create output file name (if not specified by user)
                if (string.IsNullOrEmpty(outputFilePath))
                {
                    string directory = Path.GetDirectoryName(jsFilePath) ?? string.Empty;
                    string fileName = Path.GetFileNameWithoutExtension(jsFilePath);
                    string extension = Path.GetExtension(jsFilePath);
                    outputFilePath = Path.Combine(directory, $"{fileName}_obfuscated{extension}");
                }
                
                // Write obfuscated code to file
                File.WriteAllText(outputFilePath, obfuscatedCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during processing: {ex.Message}");
                Console.Read();
            }
        }

        /// <summary>
        /// Applies advanced obfuscation strategies using the Strategy pattern
        /// </summary>
        /// <param name="code">JavaScript code to be obfuscated</param>
        /// <returns>Obfuscated JavaScript code</returns>
        static string ApplyObfuscationStrategies(string code)
        {
            // Create obfuscation context
            var context = new ObfuscationContext();
            
            // Add strategies to the context
            context.AddStrategy(new StringEncryptionStrategy());
            context.AddStrategy(new JunkCodeStrategy());
            context.AddStrategy(new ControlFlowStrategy());
            context.AddStrategy(new EvalWrapStrategy());
            
            // Apply all strategies
            return context.ApplyStrategies(code);
        }
    }
}
