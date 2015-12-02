﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFRESTService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private MindReaderEntities dbEntities;

        public Service1()
        {
            dbEntities = new MindReaderEntities();
        }

        public List<questionAnswersDataContract> questionAnswers(string Char_ID)
        {
            var query = (from A in dbEntities.Questions
                         join B in dbEntities.Character_Name on A.Char_Name_ID equals B.Char_Name_ID
                         where B.Char_ID.Equals(Char_ID)
                         select new
                         {
                             A.Question_ID,
                             A.Char_Name_ID,
                             B.Char_ID,
                             A.Question,
                             A.Answer,
                             B.Char_Name,
                             B.Char_Status
                         }).ToList().OrderBy(x => Int32.Parse(x.Char_ID));

            List<questionAnswersDataContract> questionAnswersList = new List<questionAnswersDataContract>();
            query.ToList().ForEach(x =>
            {
                questionAnswersList.Add(new questionAnswersDataContract()
                {
                    Question_ID = x.Question_ID,
                    Char_Name_ID = x.Char_Name_ID,
                    Char_ID = x.Char_ID,
                    Question = x.Question,
                    Answer = x.Answer,
                    Char_Name = x.Char_Name,
                    Char_Status = x.Char_Status
                });
            });
            return questionAnswersList;
        }

        public List<CharacterTypeDataContract> GetCharacterType()
        {
            var query = (from m in dbEntities.Character_Type
                select m).Distinct();
            List<CharacterTypeDataContract> CharacterTypeList = new List<CharacterTypeDataContract>();

            query.ToList().ForEach(rec =>
            {
                CharacterTypeList.Add(new CharacterTypeDataContract
                {
                    Char_ID = rec.Char_ID,
                    Character_Type = rec.Char_Type
                });
            });
            return CharacterTypeList;
        }

        public List<CharacterNameDataContract> getCharacterNames()
        {

            List<CharacterNameDataContract> CharacterNameList = new List<CharacterNameDataContract>();

            try
            {

                var query = (from a in dbEntities.Character_Name
                             select a).ToList().OrderBy(q => Int32.Parse(q.Char_Name_ID));

                query.ToList().ForEach(rec =>
                {
                    CharacterNameList.Add(new CharacterNameDataContract
                    {
                        Char_Name_ID = rec.Char_Name_ID,
                        Char_ID = rec.Char_ID,
                        Char_Name = rec.Char_Name,
                        Char_Status = rec.Char_Status
                    });
                });
                return CharacterNameList;
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                       (ex.Message);
            }
        }
    }
}
