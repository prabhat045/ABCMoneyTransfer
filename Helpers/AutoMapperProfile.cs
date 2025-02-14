using ABCMoneyTransfer.DTOs;
using ABCMoneyTransfer.Models;
using AutoMapper;
using System.Reflection;

namespace ABCMoneyTransfer.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PartyDTO, Receiver>().ReverseMap();
            CreateMap<PaymentDetailDTO, PaymentDetail>().ReverseMap();
            CreateMap<Sender, PartyDTO>().ReverseMap();
            CreateMap<Transaction, TransactionDTO>()
                .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.Sender))
                .ForMember(dest => dest.Receiver, opt => opt.MapFrom(src => src.Receiver))
                .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.PaymentDetail.BankName))
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.PaymentDetail.AccountNumber))
                .ForMember(dest => dest.TransferAmount, opt => opt.MapFrom(src => src.PaymentDetail.TransferAmount))
                .ForMember(dest => dest.ExchangeRate, opt => opt.MapFrom(src => src.PaymentDetail.ExchangeRate))
                .ForMember(dest => dest.PayoutAmount, opt => opt.MapFrom(src => src.PayoutAmount))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.TransactionId, opt => opt.MapFrom(src => src.Id));

        }
    }
}
