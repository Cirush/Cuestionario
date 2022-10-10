namespace Cuestionario.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Cuestionario.Models;
    using Cuestionario.Repository;
    using Cuestionario.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Primitives;

    public class QuestionaryController : Controller
    {
        private IQuestionRepository _questionRepository;
        private IMapper _mapper;

        public QuestionaryController(IQuestionRepository questionRepository, IMapper mapper)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            QuestionListViewModel questionsListViewModel;

            try
            {
                var questions = await _questionRepository.GetAsync();

                questionsListViewModel = new QuestionListViewModel()
                {
                    Questions = questions
                };

            }
            catch
            {
                questionsListViewModel = new QuestionListViewModel();
            }
            
            return View(questionsListViewModel);            
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuestionViewModel questionViewModel)
        {

            try
            {
                if(IsQuestionValid(questionViewModel))
                {
                    var question = _mapper.Map<Question>(questionViewModel);
                    await _questionRepository.CreateAsync(question);
                }
            }
            catch
            {

            }
            ViewData["Title"] = "Crear Pregunta";
            ViewData["Action"] = "Create";
            ViewData["SubmitActionLabel"] = "Crear";
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Title"] = "Crear Pregunta";
            ViewData["Action"] = "Create";
            ViewData["SubmitActionLabel"] = "Crear";
            return View();
        }
        
        public async Task<IActionResult> Delete(string id)
        {
            await _questionRepository.RemoveAsync(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(string id)
        {
            var question = await _questionRepository.GetAsync(id);
            var questionViewModel = _mapper.Map<QuestionViewModel>(question);

            ViewData["Title"] = "Editar Pregunta";
            ViewData["Action"] = "Edit";
            ViewData["SubmitActionLabel"] = "Editar";

            return View("CreateOrEditQuestion",questionViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(QuestionViewModel questionViewModel)
        {
            try
            {
                var question = _mapper.Map<Question>(questionViewModel);
                await _questionRepository.UpdateAsync(question.Id, question);
            }
            catch
            {

            }

            return RedirectToAction(nameof(Index));
        }


        private bool IsQuestionValid(QuestionViewModel question)
        {
            return true;
        }
    }
}
