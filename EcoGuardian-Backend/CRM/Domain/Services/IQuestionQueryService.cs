using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoGuardian_Backend.CRM.Domain.Model.Aggregates;
using EcoGuardian_Backend.CRM.Domain.Model.ValueObjects;

namespace EcoGuardian_Backend.CRM.Domain.Services
{
    public interface IQuestionQueryService
    {
        Task<IEnumerable<Question>> GetQuestionsByPlantId(int plantId); 
        Task<IEnumerable<Question>> GetQuestionsByUserId(int userId);
        Task<IEnumerable<Question>> GetQuestionsByState(QuestionState questionState);
        

        
        Task<Question> GetQuestionById(int questionId);
        Task<IEnumerable<Question>> GetAllQuestions();
    }
}