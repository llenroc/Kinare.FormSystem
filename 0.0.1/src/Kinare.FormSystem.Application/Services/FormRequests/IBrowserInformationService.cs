﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Kinare.FormSystem.Dtos.FormRequests;
using Kinare.FormSystem.FormRequests;
using System;

namespace Kinare.FormSystem.Services.FormRequests
{
    public interface IBrowserInformationService : IAsyncCrudAppService<BrowserInformationDto, Guid, PagedResultRequestDto, BrowserInformationDto>
    {
    }
}