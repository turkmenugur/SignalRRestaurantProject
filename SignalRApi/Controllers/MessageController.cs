using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        //Listeleme
        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetListAll();
            return Ok(_mapper.Map<List<ResultMessageDto>>(values));
        }

        //Ekleme
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            createMessageDto.MessageSendDate = DateTime.Now;
            createMessageDto.Status = false;
            var value = _mapper.Map<Message>(createMessageDto);
            _messageService.TAdd(value);
            return Ok("Mesaj başarılı bir şekilde gönderildi.");
        }

        //Silme
        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetByID(id);
            _messageService.TDelete(value);
            return Ok("Mesaj silindi");
        }

        //Güncelleme
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var value = _mapper.Map<Message>(updateMessageDto);
            _messageService.TUpdate(value);
            return Ok("Mesaj güncellendi");
        }

        //ID'ye göre
        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetByID(id);
            return Ok(_mapper.Map<GetByIdMessageDto>(value));
        }
    }
}
