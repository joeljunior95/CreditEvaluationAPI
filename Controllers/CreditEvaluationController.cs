using Microsoft.AspNetCore.Mvc;

namespace CreditEvaluationApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CreditEvaluationController : ControllerBase
{

    private readonly ILogger<CreditEvaluationController> _logger;

    public CreditEvaluationController(ILogger<CreditEvaluationController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public CreditEvaluation Get(CreditRequest request)
    {
        return new CreditEvaluation(request);

    }
}
