using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class ReportService
    {
        private readonly SalesRecordsService _salesRecordsService;

        public ReportService(SalesRecordsService salesRecordsService)
        {
            _salesRecordsService = salesRecordsService;
        }

        public async Task<ViewAsPdf> GenerateSimpleSearchPdf(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            if (!maxDate.HasValue)
                maxDate = DateTime.Now;

            var result = await _salesRecordsService.FindByDateAsync(minDate, maxDate);

            return new ViewAsPdf("SimpleSearchPdf", result)
            {
                FileName = "RelatorioSimples.pdf",
                ContentDisposition = Rotativa.AspNetCore.Options.ContentDisposition.Inline
            };
        }

        public async Task<ViewAsPdf> GenerateGroupingSearchPdf(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            if (!maxDate.HasValue)
                maxDate = DateTime.Now;

            var result = await _salesRecordsService.FindByDateGroupingAsync(minDate, maxDate);

            return new ViewAsPdf("GroupingSearchPdf", result)
            {
                FileName = "RelatorioGrupo.pdf",
                ContentDisposition = Rotativa.AspNetCore.Options.ContentDisposition.Inline
            };
        }

    }
}
