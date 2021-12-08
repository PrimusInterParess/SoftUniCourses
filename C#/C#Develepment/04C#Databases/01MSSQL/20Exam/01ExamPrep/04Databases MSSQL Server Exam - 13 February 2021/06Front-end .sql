select f.Id,f.Name,f.Size
from Files as f
where Size> 1000 and CHARINDEX( 'html',f.Name)>0
order by Size desc,id,Name