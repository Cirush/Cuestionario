using System;
using AutoMapper;
using Cuestionario.Models;
using Cuestionario.ViewModels;

namespace Cuestionario.Infrastructure.Automapper.Profiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, QuestionViewModel>()
                .ReverseMap();
        }
    }
}

