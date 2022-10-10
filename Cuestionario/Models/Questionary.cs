using System;
namespace Cuestionario.Models
{
    public class Questionary
    {
        public uint NumberOfQuestions { get; set; }
        public uint NumberOfCorrectQuestions { get; set; }
        public uint NumberOfWrongQuestions { get; set; }
        public uint Score { get; set; }
    }
}

