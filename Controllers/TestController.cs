using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LocalizationGlobalization.Models;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;

namespace LocalizationGlobalization.Controllers;

public class TestController : Controller
{
    private readonly IStringLocalizer<SharedResource> _sharedResourceLLocalizer;
    
    public TestController(IStringLocalizer<SharedResource> sharedResourceLLocalizer)
    {
        _sharedResourceLLocalizer = sharedResourceLLocalizer;
    }

    [HttpGet("GetValue")]
    public IActionResult Index()
    {
        var hello = _sharedResourceLLocalizer.GetString("Hello").Value ?? "";
        var dos = _sharedResourceLLocalizer["Hello"];
        return Ok(dos);
    }
}
