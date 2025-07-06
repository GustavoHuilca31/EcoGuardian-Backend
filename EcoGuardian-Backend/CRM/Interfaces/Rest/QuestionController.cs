
using EcoGuardian_Backend.CRM.Domain.Model.Commands;
using EcoGuardian_Backend.CRM.Domain.Services;
using EcoGuardian_Backend.CRM.Interfaces.Rest.Resources;
using EcoGuardian_Backend.CRM.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace EcoGuardian_Backend.CRM.Interfaces.Rest
{
    [ApiController]
    [ProducesResponseType(500)]
    [Route("api/v1/questions")]
    public class QuestionController(
        IQuestionCommandService questionCommandService,
        IQuestionQueryService questionQueryService,
        IAnswerCommandService answerCommandService,
        IAnswerQueryService answerQueryService,
        IAddedQuestionEventHandler addedQuestionEventHandler) : ControllerBase
    {

        [HttpPost]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RegisterQuestion([FromForm] RegisterQuestionCommand command)
        {
            var question = await questionCommandService.Handle(command);
            var questionResource = QuestionResourceFromEntityAssembler.ToResourceFromEntity(question);
            return Ok(questionResource);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateQuestion([FromBody] UpdateQuestionCommand command)
        {
            await questionCommandService.Handle(command);
            var question = await questionQueryService.GetQuestionById(command.QuestionId);
            var updatedQuestion = QuestionResourceFromEntityAssembler.ToResourceFromEntity(question);
            return Ok(updatedQuestion);
        }

        [HttpGet("{questionId:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetQuestionById(int questionId)
        {
            var question = await questionQueryService.GetQuestionById(questionId);
            if (question == null)
            {
                return NotFound();
            }
            var questionResource = QuestionResourceFromEntityAssembler.ToResourceFromEntity(question);

            return Ok(questionResource);
        }

        // By uSer ID
        [HttpGet("user/{userId:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetQuestionsByUserId(int userId)
        {
            var questions = await questionQueryService.GetQuestionsByUserId(userId);
            if (questions == null || !questions.Any())
            {
                return NotFound();
            }
            var questionsResource = questions.Select(QuestionResourceFromEntityAssembler.ToResourceFromEntity).ToList();
            return Ok(questionsResource);
        }

        // By Plant ID
        [HttpGet("plant/{plantId:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetQuestionsByPlantId(int plantId)
        {
            var questions = await questionQueryService.GetQuestionsByPlantId(plantId);
            if (questions == null || !questions.Any())
            {
                return NotFound();
            }
            var questionsResource = questions.Select(QuestionResourceFromEntityAssembler.ToResourceFromEntity).ToList();
            return Ok(questionsResource);
        }

        [HttpGet("{questionId:int}/answers")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAnswersByQuestionId(int questionId)
        {
            var answers = await answerQueryService.GetAnswersByQuestionId(questionId);
            var question = await questionQueryService.GetQuestionById(questionId);
            if (answers == null || !answers.Any() || question == null)
            {
                //avoid sending error 500
                return Ok(new List<AnswerResource>());
            }
            var answersResource = answers.Select(answer => AnswerResourceFromEntityAssembler.FromEntity(answer, question)).ToList();
            return Ok(answersResource);
        }

        [HttpPost("{questionId:int}/answers")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RegisterAnswer(int questionId, [FromBody] RegisterAnswerResource resource)
        {
            var command = RegisterAnswerCommandFromResourceAssembler.toCommandFromResource(resource, questionId);

            await answerCommandService.Handle(command);
            await addedQuestionEventHandler.HandleAnswerAddedAsync(questionId);

            var answer = await answerQueryService.GetAnswersByQuestionId(questionId);

            var question = await questionQueryService.GetQuestionById(questionId);
            if (answer == null || !answer.Any() || question == null)
            {
                return NotFound();
            }
            var answersResource = answer.Select(answer => AnswerResourceFromEntityAssembler.FromEntity(answer, question)).ToList();
            return Ok(answersResource);
        }

        //Get all questions
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllQuestions()
        {
            var questions = await questionQueryService.GetAllQuestions();
            if (questions == null || !questions.Any())
            {
                //empty list
                // show message that there are no questions in the response
                Console.WriteLine("No questions found.");
                return Ok(new List<QuestionResource>());
            }
            var questionsResource = questions.Select(QuestionResourceFromEntityAssembler.ToResourceFromEntity).ToList();
            return Ok(questionsResource);
        }

    }
}