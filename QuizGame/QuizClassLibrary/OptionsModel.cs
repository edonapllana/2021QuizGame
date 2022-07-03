using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizClassLibrary
{
    public class OptionsModel
    {
        public int optionID { get; set; }
        public string optionContent { get; set; }
        public bool isCorrect { get; set; }
        public int questionID { get; set; }

        public string CheckFileds(OptionsModel option)
        {
            if (string.IsNullOrEmpty(option.optionContent))
                return "Te shkruhet opsioni i pytjes";


            return string.Empty;
        }

        public bool Create(OptionsModel options)
        {
            using (QuizEntities conn = new QuizEntities())
            {
                var option = conn.Options.Add(new Option()
                {
                    optionContent = options.optionContent,
                    isCorrect = options.isCorrect,
                    questionID = options.questionID
                });
                conn.SaveChanges();

                if (option == null)
                    return false;
                else
                    return true;
            }
        }

        public List<OptionsModel> getOptions(int questionID = 0)
        {
            using (QuizEntities conn = new QuizEntities())
            {
                var option = new List<Option>();

                if (questionID != 0)
                    option = conn.Options.Where(x => x.questionID == questionID).ToList();
                else
                    option = conn.Options.ToList();

                var optionR = option
                    .Select(x => new OptionsModel()
                    {
                        optionID = x.optionID,
                        optionContent = x.optionContent,
                        isCorrect = x.isCorrect,
                        questionID = x.questionID
                    })
                    .ToList();

                return optionR;
            }
        }

        public bool Delete(int optionID)
        {
            using (QuizEntities conn = new QuizEntities())
            {
                var option = conn.Options.Find(optionID);

                if (option == null)
                    return false;
                   
                else
                {
                    conn.Options.Remove(option);
                    conn.SaveChanges();
                    return true;
                }
            }
        }
        public bool Update(OptionsModel option)
        {
            using (QuizEntities conn = new QuizEntities())
            {
                var op = conn.Options.Find(option.optionID);

                if (op == null)
                    return false;
                else
                {
                    op.optionContent = option.optionContent;
                    op.isCorrect = option.isCorrect;
                    conn.SaveChanges();
                    return true;
                }
            }
        }
    }
}
