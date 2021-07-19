using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam.Models
{
    [Serializable]
    class Question
    {
        public int KnowledgesectionId { get; set; }
        public string Text { get; set; }
        public List<Answer> answers;
        public override string ToString()
        {
            return $"Knowledge section: {KnowledgesectionId}\nQuestion:\n{Text}\nAnswers:\n{String.Join("\n", answers.Select(a =>$"Index:{answers.IndexOf(a)}, {a.Text}"))}";
        }

        public bool Run()
        {
            bool result = false;
            Console.WriteLine(this);
            Console.WriteLine("Enter the number of the true answer(s)(separate space");
            var forCheck = Console.ReadLine().Split(" ").ToList();
            var chekAnswers = forCheck.Select(c => int.TryParse(c, out int n)?n:n).ToList();
            var trueAnswers = answers.Where(a=>a.IsTrue==true).Select(a => answers.IndexOf(a)).ToList();
            var res = chekAnswers.Except(trueAnswers);
            if(res.Count()==0)
            {
                result = true;
            }
            return result;
        }
    }
}
