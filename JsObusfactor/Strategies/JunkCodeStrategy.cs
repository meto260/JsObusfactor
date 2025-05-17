using System;
using System.Collections.Generic;

namespace JsObusfactor.Strategies
{
    /// <summary>
    /// Strategy for adding junk code to JavaScript code
    /// </summary>
    public class JunkCodeStrategy : IObfuscationStrategy
    {
        /// <summary>
        /// Adds non-functional junk code to the JavaScript code
        /// </summary>
        /// <param name="code">JavaScript code to be obfuscated</param>
        /// <returns>JavaScript code with added junk code</returns>
        public string Apply(string code)
        {
            // Generate a random variable name
            string junkVarName = $"_$j{Guid.NewGuid().ToString("N").Substring(0, 6)}";
            
            // Junk code pieces
            List<string> junkPieces = new List<string>
            {
                $"var {junkVarName}=function(x){{return x*Math.random()}};\n",
                $"try{{if({junkVarName}(1)>0.5){{console;}}}}catch(e){{}}\n",
                $"if(typeof window!=='undefined'){{setTimeout(function(){{{junkVarName}(2)}},0)}}\n",
                $"/*{Guid.NewGuid()}*/\n",
                $"Object.defineProperty(window,'{junkVarName}_'+Date.now(),{{get:function(){{return {junkVarName}(3)}}}});\n",
                $"!function(){{{junkVarName}(4)}}();\n"
            };
            
            // Select a random junk piece
            Random rnd = new Random();
            string junkCode = junkPieces[rnd.Next(junkPieces.Count)];
            
            // Start the code with junk code
            return $"{junkCode}{code}";
        }
    }
}