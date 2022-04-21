using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebAppDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

            try
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i == 56)
                    {
                        throw new System.Exception("This is an explicit Exception!");
                    }
                    else
                    {
                        // _logger.LogInformation("The value of this variable is {iVariable}", i);
                    }
                }
            }
            catch (System.Exception ex)
            {

                // _logger.LogError(ex, " Abbiamo una Exception");
            }
            // _logger.LogInformation("Ho richesto la pagina Index! :)");
        }
    }
}
