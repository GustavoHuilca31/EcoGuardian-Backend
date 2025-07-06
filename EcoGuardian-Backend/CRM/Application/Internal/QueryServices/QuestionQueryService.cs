
using EcoGuardian_Backend.CRM.Domain.Model.Aggregates;
using EcoGuardian_Backend.CRM.Domain.Model.ValueObjects;
using EcoGuardian_Backend.CRM.Domain.Repositories;
using EcoGuardian_Backend.CRM.Domain.Services;
namespace EcoGuardian_Backend.CRM.Application.Internal.QueryServices
{
    public class QuestionQueryService(IQuestionRepository questionRepository) : IQuestionQueryService
    {
        

        public async Task<Question> GetQuestionById(int questionId)
        {
            try
            {
                var question = await questionRepository.GetQuestionById(questionId);
                if (question == null)
                {
                    throw new KeyNotFoundException($"Question with ID {questionId} not found.");
                }
                return question;
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception($"An error occurred while retrieving the question with ID {questionId}: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Question>> GetQuestionsByPlantId(int plantId)
        {
            try
            {
                var questions = await questionRepository.GetQuestionsByPlantId(plantId);
                if (questions == null)
                {
                    throw new KeyNotFoundException($"No questions found for Plant ID {plantId}.");
                }
                return questions;
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception($"An error occurred while retrieving questions for Plant ID {plantId}: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Question>> GetQuestionsByState(QuestionState questionState)
        {

            try
            {
                var questions = await questionRepository.GetQuestionsByState(questionState);
                if (questions == null)
                {
                    throw new KeyNotFoundException($"No questions found with state {questionState}.");
                }
                return questions;
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception($"An error occurred while retrieving questions with state {questionState}: {ex.Message}", ex);
            }

        }

        public async Task<IEnumerable<Question>> GetQuestionsByUserId(int userId)
        {

            try
            {
                var questions = await questionRepository.GetQuestionsByUserId(userId);
                if (questions == null)
                {
                    throw new KeyNotFoundException($"No questions found for User ID {userId}.");
                }
                return questions;
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception($"An error occurred while retrieving questions for User ID {userId}: {ex.Message}", ex);
            }

        }

        public async Task<IEnumerable<Question>> GetAllQuestions()
        {
            try
            {
                var questions = await questionRepository.GetAllQuestions();
                if (questions == null || !questions.Any())
                {
                    // throw an empty list
                    return new List<Question>();

                }
                return questions;
            }
            catch (Exception ex)
            {
                //return an empty list
                throw new Exception($"An error occurred while retrieving all questions: {ex.Message}", ex);
            }
        }
    }
}