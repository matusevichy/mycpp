using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Models
{
    [Serializable]
    class Question
    {
        public int Id { get; set; }
        public int KnowledgesectionId { get; set; }
        public string Text { get; set; }
    }
}
