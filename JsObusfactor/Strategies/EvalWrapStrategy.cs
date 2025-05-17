using System;
using System.Text;

namespace JsObusfactor.Strategies
{
    /// <summary>
    /// Strategy for wrapping JavaScript code with eval function
    /// </summary>
    public class EvalWrapStrategy : IObfuscationStrategy
    {
        /// <summary>
        /// Wraps JavaScript code with eval function to make it harder to analyze
        /// </summary>
        /// <param name="code">JavaScript code to be obfuscated</param>
        /// <returns>JavaScript code wrapped with eval</returns>
        public string Apply(string code)
        {
            // First encode the code with Base64
            string base64Code = Convert.ToBase64String(Encoding.UTF8.GetBytes(code));
            
            // Create a code wrapped with classic eval anti-debugging techniques
            return $@"
(function() {{
    var _0x{Guid.NewGuid().ToString("N").Substring(0, 6)} = atob('{base64Code}');
    var _0x{Guid.NewGuid().ToString("N").Substring(0, 6)} = function(s) {{
        return decodeURIComponent(s.split('').map(function(c) {{
            return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        }}).join(''));
    }};
    try {{
        if (!/\\[native code\\]/.test(window.eval.toString())) {{
            throw new Error('Debugger detected');
        }}
        eval(_0x{Guid.NewGuid().ToString("N").Substring(0, 6)});
    }} catch(e) {{
        return eval(_0x{Guid.NewGuid().ToString("N").Substring(0, 6)});
    }}
}})();
";
        }
    }
}