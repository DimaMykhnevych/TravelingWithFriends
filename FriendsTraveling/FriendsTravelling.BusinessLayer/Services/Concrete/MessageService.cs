using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MessageDto>> GetChatMessages(int chatId)
        {
            IEnumerable<Message> messages = await _messageRepository.GetChatMessages(chatId);
            return _mapper.Map<IEnumerable<MessageDto>>(messages);
        }

        public async Task<MessageDto> PostMessage(MessageDto messageDto)
        {
            messageDto.SendingDate = DateTime.Now;
            Message message = await _messageRepository.Insert(_mapper.Map<Message>(messageDto));
            await _messageRepository.Save();
            Message messageWithUser = await _messageRepository.GetMessageWithSenderById(message.Id);
            return _mapper.Map<MessageDto>(messageWithUser);
        }
    }
}
