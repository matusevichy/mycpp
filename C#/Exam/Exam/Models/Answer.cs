using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Models
{
    [Serializable]
    class Answer
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public bool IsTrue  { get; set; }
    }
}
