﻿using CVBuilder.Domain.CVEntites;
using CVBuilder.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Application.features.ResumeInterfaces
{
	public interface IResumeRepository : IRepositoryBase<Resume, int>
	{
		Task<Resume> GetCVByUserId(Guid userId, int tempId);
		Task<bool> UpdateCVByUserIdAndTempId(Resume cVTemplate);

		Task<bool> DeleteResumeData(Resume cVTemplate);
		Task<IList<Resume>> GetAllResumeByUser(Guid userId);

	}
}
