select LG_dist_Code,m.Mandcode,VillCode,VillName,VillName_Tel,VillCode_LG 
from msp.dbo.EP_Mst_Village v inner join msp.dbo.EP_Mst_Mandal m 
on v.DistCode=m.DistCode and v.MandCode=m.MandCode where LG_dist_Code=501 order by m.Mandcode,VillName

select v.DistCode,V.MandCode,m.RB_Code,VillCode,v.rb_code,VillName  from Seed_Mst_Village v inner join Seed_Mst_Mandal m on v.DistCode=m.DistCode and v.MandCode=m.MandCode
and v.Yr=m.Yr and v.Seasn=m.Seasn where v.Yr='2020-21' and v.DistCode=501  and v.rb_Code is null 
order by m.RB_Code, v.VillName

update Seed_Mst_Village set rb_code=1301024 where DistCode=501 AND MandCode='01' 
AND VillCode='005' AND Yr='2020-21' AND Seasn='Kharif'