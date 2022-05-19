namespace FrontEnd.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models;
    using Newtonsoft.Json;
    using Services;
    using Services.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    //[Authorize]
    public class BankPostingController : Controller
    {
        private readonly IFinanceHttpClient _treasuryHttpClient;

        public BankPostingController(IFinanceHttpClient treasuryHttpClient)
        {
            _treasuryHttpClient = treasuryHttpClient;
        }

        // GET: Payable/Create
        public async Task<IActionResult> Create()
        {
            var httpClient = await _treasuryHttpClient
                .GetClient();

            var creditorResponse = await httpClient
                .GetAsync("creditor");

            if (creditorResponse.IsSuccessStatusCode) //TODO:need to be improved
            {
                //success
            }
            else if (creditorResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("AccessDenied", "Authorization");
            }
            else
            {
                //Error fatal !
                throw new Exception($"A problem happened while calling the API: {creditorResponse.ReasonPhrase}");
            }

            var creditorContent = await creditorResponse
                .Content
                .ReadAsAsync<Envelope<List<GetCreditorDto>>>();

            var categoryResponse = await httpClient
                .GetAsync("category");

            if (categoryResponse.IsSuccessStatusCode) //TODO:need to be improved
            {
                //success
            }
            else if (categoryResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("AccessDenied", "Authorization");
            }
            else
            {
                //Error fatal !
                throw new Exception($"A problem happened while calling the API: {categoryResponse.ReasonPhrase}");
            }

            var categoryContent = await categoryResponse
                .Content
                .ReadAsAsync<Envelope<List<GetCategoryDto>>>();

            var bankAccountResponse = await httpClient
                .GetAsync("bankaccount");

            if (bankAccountResponse.IsSuccessStatusCode) //TODO:need to be improved
            {
                //success
            }
            else if (bankAccountResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("AccessDenied", "Authorization");
            }
            else
            {
                //Error fatal !
                throw new Exception($"A problem happened while calling the API: {bankAccountResponse.ReasonPhrase}");
            }

            var bankAccountContent = await bankAccountResponse
                .Content
                .ReadAsAsync<Envelope<List<GetBankAccountDto>>>();

            var model = new CreateBankPostingModel
            {
                Creditor = new List<SelectListItem>(),
                Category = new List<SelectListItem>(),
                BankAccount = new List<SelectListItem>()
            };

            if (creditorContent.Result != null && creditorContent.Result.Any())
            {
                foreach (var result in creditorContent.Result)
                {
                    var item = new SelectListItem(result.Name, result.Id.ToString());

                    model.Creditor.Add(item);
                }
            }

            if (categoryContent.Result != null && categoryContent.Result.Any())
            {
                foreach (var result in categoryContent.Result)
                {
                    var item = new SelectListItem(result.Name, result.Id.ToString());

                    model.Category.Add(item);
                }
            }

            if (bankAccountContent.Result != null && bankAccountContent.Result.Any())
            {
                foreach (var result in bankAccountContent.Result)
                {
                    var item = new SelectListItem(result.AccountNumber, result.Id.ToString());

                    model.BankAccount.Add(item);
                }
            }

            return View(model);
        }

        /// POST: Payable/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBankPostingModel model)
        {
            try
            {
                var dto = new CreateBankPostingDto
                {
                    CreditorId = model.CreditorId,
                    DocumentNumber = model.DocumentNumber,
                    Description = model.Description,
                    PaymentDate = model.PaymentDate,
                    DocumentDate = model.DocumentDate,
                    CategoryId = model.CategoryId,
                    Amount = model.Amount,
                    BankAccountId = model.BankAccountId,
                    DueDate = model.DueDate,
                    Type = model.Type
                };

                var modelSerialized = JsonConvert.SerializeObject(dto);

                var httpClient = await _treasuryHttpClient.GetClient();

                var response = await httpClient.PostAsync(
                        requestUri: "payable",
                        content: new StringContent(modelSerialized, System.Text.Encoding.Unicode, "application/json"));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //// GET: Payable/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var httpClient = await _treasuryHttpClient
                .GetClient();

            var creditorResponse = await httpClient
                .GetAsync("creditor");

            if (creditorResponse.IsSuccessStatusCode) //TODO:need to be improved
            {
                //success
            }
            else if (creditorResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("AccessDenied", "Authorization");
            }
            else
            {
                //Error fatal !
                throw new Exception($"A problem happened while calling the API: {creditorResponse.ReasonPhrase}");
            }

            var creditorContent = await creditorResponse
                .Content
                .ReadAsAsync<Envelope<List<GetCreditorDto>>>();

            var categoryResponse = await httpClient
                .GetAsync("category");

            if (categoryResponse.IsSuccessStatusCode) //TODO:need to be improved
            {
                //success
            }
            else if (categoryResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("AccessDenied", "Authorization");
            }
            else
            {
                //Error fatal !
                throw new Exception($"A problem happened while calling the API: {categoryResponse.ReasonPhrase}");
            }

            var categoryContent = await categoryResponse
                .Content
                .ReadAsAsync<Envelope<List<GetCategoryDto>>>();

            var bankAccountResponse = await httpClient
                .GetAsync("bankaccount");

            if (bankAccountResponse.IsSuccessStatusCode) //TODO:need to be improved
            {
                //success
            }
            else if (bankAccountResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("AccessDenied", "Authorization");
            }
            else
            {
                //Error fatal !
                throw new Exception($"A problem happened while calling the API: {bankAccountResponse.ReasonPhrase}");
            }

            var bankAccountContent = await bankAccountResponse
                .Content
                .ReadAsAsync<Envelope<List<GetBankAccountDto>>>();

            var bankPostingResponse = await httpClient
                .GetAsync($"payable/{id}");

            if (bankAccountResponse.IsSuccessStatusCode) //TODO:need to be improved
            {
                //success
            }
            else if (bankAccountResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("AccessDenied", "Authorization");
            }
            else
            {
                //Error fatal !
                throw new Exception($"A problem happened while calling the API: {bankAccountResponse.ReasonPhrase}");
            }

            var bankPostingContent = await bankPostingResponse
                .Content
                .ReadAsAsync<Envelope<GetBankPostingByIdDto>>();

            var model = new DeleteBankPostingModel
            {
                Creditor = new List<SelectListItem>(),
                Category = new List<SelectListItem>(),
                BankAccount = new List<SelectListItem>(),
                CreditorId = bankPostingContent.Result.CreditorId,
                DocumentNumber = bankPostingContent.Result.DocumentNumber,
                Description = bankPostingContent.Result.Description,
                PaymentDate = bankPostingContent.Result.PaymentDate,
                DocumentDate = bankPostingContent.Result.DocumentDate,
                CategoryId = bankPostingContent.Result.CategoryId,
                DueDate = bankPostingContent.Result.DueDate,
                BankAccountId = bankPostingContent.Result.BankAccountId,
                Amount = bankPostingContent.Result.Amount
            };

            if (creditorContent.Result != null && creditorContent.Result.Any())
            {
                foreach (var result in creditorContent.Result)
                {
                    var item = new SelectListItem(result.Name, result.Id.ToString());

                    model.Creditor.Add(item);
                }
            }

            if (categoryContent.Result != null && categoryContent.Result.Any())
            {
                foreach (var result in categoryContent.Result)
                {
                    var item = new SelectListItem(result.Name, result.Id.ToString());

                    model.Category.Add(item);
                }
            }

            if (bankAccountContent.Result != null && bankAccountContent.Result.Any())
            {
                foreach (var result in bankAccountContent.Result)
                {
                    var item = new SelectListItem(result.AccountNumber, result.Id.ToString());

                    model.BankAccount.Add(item);
                }
            }

            return View(model);
        }

        //// POST: Payable/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(
            int id,
            DeleteBankPostingModel model)
        {
            try
            {
                var httpClient = await _treasuryHttpClient.GetClient();

                var response = await httpClient.DeleteAsync(
                    requestUri: $"payable/{id}");

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //// GET: Payable/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var httpClient = await _treasuryHttpClient
                .GetClient();

            var creditorResponse = await httpClient
                .GetAsync("creditor");

            if (creditorResponse.IsSuccessStatusCode) //TODO:need to be improved
            {
                //success
            }
            else if (creditorResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("AccessDenied", "Authorization");
            }
            else
            {
                //Error fatal !
                throw new Exception($"A problem happened while calling the API: {creditorResponse.ReasonPhrase}");
            }

            var creditorContent = await creditorResponse
                .Content
                .ReadAsAsync<Envelope<List<GetCreditorDto>>>();

            var categoryResponse = await httpClient
                .GetAsync("category");

            if (categoryResponse.IsSuccessStatusCode) //TODO:need to be improved
            {
                //success
            }
            else if (categoryResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("AccessDenied", "Authorization");
            }
            else
            {
                //Error fatal !
                throw new Exception($"A problem happened while calling the API: {categoryResponse.ReasonPhrase}");
            }

            var categoryContent = await categoryResponse
                .Content
                .ReadAsAsync<Envelope<List<GetCategoryDto>>>();

            var bankAccountResponse = await httpClient
                .GetAsync("bankaccount");

            if (bankAccountResponse.IsSuccessStatusCode) //TODO:need to be improved
            {
                //success
            }
            else if (bankAccountResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("AccessDenied", "Authorization");
            }
            else
            {
                //Error fatal !
                throw new Exception($"A problem happened while calling the API: {bankAccountResponse.ReasonPhrase}");
            }

            var bankAccountContent = await bankAccountResponse
                .Content
                .ReadAsAsync<Envelope<List<GetBankAccountDto>>>();

            var billResponse = await httpClient
                .GetAsync($"payable/{id}");

            if (bankAccountResponse.IsSuccessStatusCode) //TODO:need to be improved
            {
                //success
            }
            else if (bankAccountResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("AccessDenied", "Authorization");
            }
            else
            {
                //Error fatal !
                throw new Exception($"A problem happened while calling the API: {bankAccountResponse.ReasonPhrase}");
            }

            var billContent = await billResponse
                .Content
                .ReadAsAsync<Envelope<GetBankPostingByIdDto>>();

            var model = new DetailBankPostingModel
            {
                Creditor = new List<SelectListItem>(),
                Category = new List<SelectListItem>(),
                BankAccount = new List<SelectListItem>(),
                CreditorId = billContent.Result.CreditorId,
                DocumentNumber = billContent.Result.DocumentNumber,
                Description = billContent.Result.Description,
                PaymentDate = billContent.Result.PaymentDate,
                DocumentDate = billContent.Result.DocumentDate,
                CategoryId = billContent.Result.CategoryId,
                DueDate = billContent.Result.DueDate,
                BankAccountId = billContent.Result.BankAccountId,
                Amount = billContent.Result.Amount,
                Id = id
            };

            if (creditorContent.Result != null && creditorContent.Result.Any())
            {
                foreach (var result in creditorContent.Result)
                {
                    var item = new SelectListItem(result.Name, result.Id.ToString());

                    model.Creditor.Add(item);
                }
            }

            if (categoryContent.Result != null && categoryContent.Result.Any())
            {
                foreach (var result in categoryContent.Result)
                {
                    var item = new SelectListItem(result.Name, result.Id.ToString());

                    model.Category.Add(item);
                }
            }

            if (bankAccountContent.Result != null && bankAccountContent.Result.Any())
            {
                foreach (var result in bankAccountContent.Result)
                {
                    var item = new SelectListItem(result.AccountNumber, result.Id.ToString());

                    model.BankAccount.Add(item);
                }
            }

            return View(model);
        }

        //// GET: Payable/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var httpClient = await _treasuryHttpClient
                .GetClient();

            var creditorResponse = await httpClient
                .GetAsync("creditor");

            if (creditorResponse.IsSuccessStatusCode) //TODO:need to be improved
            {
                //success
            }
            else if (creditorResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("AccessDenied", "Authorization");
            }
            else
            {
                //Error fatal !
                throw new Exception($"A problem happened while calling the API: {creditorResponse.ReasonPhrase}");
            }

            var creditorContent = await creditorResponse
                .Content
                .ReadAsAsync<Envelope<List<GetCreditorDto>>>();

            var categoryResponse = await httpClient
                .GetAsync("category");

            if (categoryResponse.IsSuccessStatusCode) //TODO:need to be improved
            {
                //success
            }
            else if (categoryResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("AccessDenied", "Authorization");
            }
            else
            {
                //Error fatal !
                throw new Exception($"A problem happened while calling the API: {categoryResponse.ReasonPhrase}");
            }

            var categoryContent = await categoryResponse
                .Content
                .ReadAsAsync<Envelope<List<GetCategoryDto>>>();

            var bankAccountResponse = await httpClient
                .GetAsync("bankaccount");

            if (bankAccountResponse.IsSuccessStatusCode) //TODO:need to be improved
            {
                //success
            }
            else if (bankAccountResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("AccessDenied", "Authorization");
            }
            else
            {
                //Error fatal !
                throw new Exception($"A problem happened while calling the API: {bankAccountResponse.ReasonPhrase}");
            }

            var bankAccountContent = await bankAccountResponse
                .Content
                .ReadAsAsync<Envelope<List<GetBankAccountDto>>>();

            var bankPostingResponse = await httpClient
                .GetAsync($"payable/{id}");

            if (bankAccountResponse.IsSuccessStatusCode) //TODO:need to be improved
            {
                //success
            }
            else if (bankAccountResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("AccessDenied", "Authorization");
            }
            else
            {
                //Error fatal !
                throw new Exception($"A problem happened while calling the API: {bankAccountResponse.ReasonPhrase}");
            }

            var bankPostingContent = await bankPostingResponse
                .Content
                .ReadAsAsync<Envelope<GetBankPostingByIdDto>>();

            var model = new EditBankPostingModel
            {
                Creditor = new List<SelectListItem>(),
                Category = new List<SelectListItem>(),
                BankAccount = new List<SelectListItem>(),
                CreditorId = bankPostingContent.Result.CreditorId,
                DocumentNumber = bankPostingContent.Result.DocumentNumber,
                Description = bankPostingContent.Result.Description,
                PaymentDate = bankPostingContent.Result.PaymentDate,
                DocumentDate = bankPostingContent.Result.DocumentDate,
                CategoryId = bankPostingContent.Result.CategoryId,
                DueDate = bankPostingContent.Result.DueDate,
                BankAccountId = bankPostingContent.Result.BankAccountId,
                Amount = bankPostingContent.Result.Amount,
                Type = bankPostingContent.Result.Type
            };

            if (creditorContent.Result != null && creditorContent.Result.Any())
            {
                foreach (var result in creditorContent.Result)
                {
                    var item = new SelectListItem(result.Name, result.Id.ToString());

                    model.Creditor.Add(item);
                }
            }

            if (categoryContent.Result != null && categoryContent.Result.Any())
            {
                foreach (var result in categoryContent.Result)
                {
                    var item = new SelectListItem(result.Name, result.Id.ToString());

                    model.Category.Add(item);
                }
            }

            if (bankAccountContent.Result != null && bankAccountContent.Result.Any())
            {
                foreach (var result in bankAccountContent.Result)
                {
                    var item = new SelectListItem(result.AccountNumber, result.Id.ToString());

                    model.BankAccount.Add(item);
                }
            }

            return View(model);
        }

        // POST: Payable/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            EditBankPostingModel model)
        {
            try
            {
                var dto = new EditBankPostingDto
                {
                    CreditorId = model.CreditorId,
                    DocumentNumber = model.DocumentNumber,
                    Description = model.Description,
                    PaymentDate = model.PaymentDate,
                    DocumentDate = model.DocumentDate,
                    CategoryId = model.CategoryId,
                    Amount = model.Amount,
                    BankAccountId = model.BankAccountId,
                    DueDate = model.DueDate,
                    Type = model.Type
                };

                var modelSerialized = JsonConvert.SerializeObject(dto);

                var httpClient = await _treasuryHttpClient.GetClient();

                var response = await httpClient.PutAsync(
                    requestUri: $"payable/{id}",
                    content: new StringContent(modelSerialized, System.Text.Encoding.Unicode, "application/json"));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Payable
        public async Task<IActionResult> Index()
        {
            var httpClient = await _treasuryHttpClient
                .GetClient();

            var response = await httpClient
                .GetAsync("payable");

            if (response.IsSuccessStatusCode) //TODO:need to be improved
            {
                //success
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("AccessDenied", "Authorization");
            }
            else
            {
                //Error fatal !
                throw new Exception($"A problem happened while calling the API: {response.ReasonPhrase}");
            }

            var content = await response
                .Content
                .ReadAsAsync<Envelope<List<GetBankPostingDto>>>();

            var bill = new List<GetBankPostingModel>();

            foreach (var item in content.Result)
            {
                var model = new GetBankPostingModel
                {
                    DueDate = item.DueDate,
                    Amount = item.Amount,
                    DocumentDate = item.DocumentDate,
                    DocumentNumber = item.DocumentNumber,
                    PaymentDate = item.PaymentDate,
                    Creditor = item.Creditor,
                    Description = item.Description,
                    Id = item.Id
                };

                bill.Add(model);
            }

            return View(bill);
        }
    }
}