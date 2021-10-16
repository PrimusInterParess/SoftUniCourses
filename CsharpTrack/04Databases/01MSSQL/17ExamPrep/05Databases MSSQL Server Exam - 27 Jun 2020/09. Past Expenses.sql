

		select sum(p.Price) from PartsNeeded as pn
			join Jobs as j on pn.JobId=j.JobId
			join Parts as p on p.PartId=pn.PartId
			where j.Status = 'finished'
			group by j.JobId

			select *
				from Jobs as j 
					join