using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Net;
using ToDoList_API.Data;
using ToDoList_API.Models;
using ToDoList_API.Models.DTO;
using ToDoList_API.Repository.IRepository;

namespace ToDoList_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListAPIController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public ToDoListAPIController(IUnitOfWork unitOfWork, ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this._response = new APIResponse();
        }

        [HttpGet("{id}", Name = "GETTODOLIST")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetToDoList(int id)
        {
            if(id == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.isSuccess = false;
                return BadRequest(_response);
            }

            var ToDoListVar = await _unitOfWork.ToDoListR.GetAsync(u => u.Id == id);
            if (ToDoListVar == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.isSuccess = false;
                return NotFound(_response);
            }
            else
            {
                var convertedvar = _mapper.Map<ToDoListMDTO>(ToDoListVar);
                _response.Result = convertedvar;
                _response.isSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetToDoLists()
        {
            var ToDoListsVar = await _unitOfWork.ToDoListR.GetAllAsync();

            if (ToDoListsVar == null)
            {
                _response.StatusCode= HttpStatusCode.NotFound;
                _response.isSuccess = false;
                return NotFound(_response);
            }
            else
            {
                _response.Result = _mapper.Map<List<ToDoListMDTO>>(ToDoListsVar);
                _response.StatusCode = HttpStatusCode.OK;
                _response.isSuccess = true;
                return Ok(_response);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> AddToDoList([FromBody] ToDoListCreateDTO dto)
        {
            if (dto == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.isSuccess = false;
                return BadRequest(_response);
            }

            if (await _unitOfWork.ToDoListR.GetAsync(u => u.Name == dto.Name) != null)
            {
				_response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string> { "ToDoList with same name already Exists" };
				_response.isSuccess = false;
                return BadRequest(_response);
			}

            dto.CreatedDate = DateOnly.FromDateTime(DateTime.Now);

            var model = _mapper.Map<ToDoListM>(dto);

            await _unitOfWork.ToDoListR.AddAsync(model);

            await _unitOfWork.SaveAsync();

            //_response.Result = _mapper.Map<ToDoListCreateDTO>(model);
            _response.Result = model;
            _response.StatusCode = HttpStatusCode.Created;
            _response.isSuccess = true;

            return CreatedAtRoute("GETTODOLIST", new { id = model.Id }, _response);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> RemoveToDoList(int id)
        {
            if (id == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string> { "Enter an Id which is greater than 0" };
                return BadRequest(_response);
            }

            var ToBeDeletedGPU = await _unitOfWork.ToDoListR.GetAsync(u => u.Id == id);

            if (ToBeDeletedGPU == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.isSuccess = false;
                return NotFound(_response);
            }

            await _unitOfWork.ToDoListR.Remove(ToBeDeletedGPU);
            await _unitOfWork.SaveAsync();
            _response.StatusCode = HttpStatusCode.OK;
            _response.isSuccess = true;
            return Ok(_response);


        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateToDoList(int id,[FromBody] ToDoListUpdateDTO dto)
        {
            if(dto == null || id != dto.Id)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.isSuccess = false;
                return BadRequest(_response);
            }
            dto.UpdatedDate = DateOnly.FromDateTime(DateTime.Now);

            var ToBeUpdatedvar = await _unitOfWork.ToDoListR.GetAsync(u=>u.Id == id); //main model

            if (ToBeUpdatedvar == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.isSuccess = false;
                return NotFound(_response);
            }

            _mapper.Map(dto,ToBeUpdatedvar); // dto to main model

            await _unitOfWork.ToDoListU.UpdateAsync(ToBeUpdatedvar);
            await _unitOfWork.SaveAsync();

            _response.Result = _mapper.Map<ToDoListUpdateDTO>(ToBeUpdatedvar);
            _response.isSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);

        }


    }
}
