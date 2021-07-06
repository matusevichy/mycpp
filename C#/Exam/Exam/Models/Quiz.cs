using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam.Models
{
    [Serializable]
    class Quiz
    {
        public int KnowledgesectionId { get; set; }
        public string Text { get; set; }
        public List<Answer> answers;
        public override string ToString()
        {
            return $"Knowledge section: {KnowledgesectionId}\nQuestion:\n{Text}\nAnswers:\n{String.Join("\n", answers.Select(a => a.Text))}";
        }

    }
}
