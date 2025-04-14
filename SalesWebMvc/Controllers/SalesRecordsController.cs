using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Services;
using Microsoft.AspNetCore.Authorization;
using Rotativa.AspNetCore;

namespace SalesWebMvc.Controllers
{
    [Authorize]
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordsService _salesRecordsService;
        private readonly ReportService _reportService;

        public SalesRecordsController(SalesRecordsService salesRecordsService, ReportService reportService)
        {
            _salesRecordsService = salesRecordsService;
            _reportService = reportService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if(!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordsService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }
        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordsService.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> SimpleSearchPdf(DateTime? minDate, DateTime? maxDate)
        {
            var pdf = await _reportService.GenerateSimpleSearchPdf(minDate, maxDate);
            return pdf;
        }

        public async Task<IActionResult> GroupingSearchPdf(DateTime? minDate, DateTime? maxDate)
        {
            var pdf = await _reportService.GenerateGroupingSearchPdf(minDate, maxDate);
            return pdf;
        }
    }
}
