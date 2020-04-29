/*INSERT INTO Seed_Mst_District(StateCode,DistCode, DistName,seed_cell_order,Yr,Seasn )
SELECT StateCode,DistCode, DistName,seed_cell_order,'2020-21','Kharif'  
FROM Seed_Mst_District where Yr='2019-20' AND Seasn='Rabi' order by seed_cell_order*/

/*INSERT INTO Seed_Mst_Mandal(DistCode, MandCode, MandName,Yr,Seasn)
SELECT DistCode, MandCode, MandName,'2020-21','Kharif'  
FROM Seed_Mst_Mandal WHERE Yr='2019-20' AND Seasn='Rabi'*/

/*INSERT INTO Seed_Mst_Village(DistCode, MandCode,VillCode,VillName,Yr,Seasn)
SELECT DistCode, MandCode,VillCode,VillName,'2020-21','Kharif'
FROM Seed_Mst_Village WHERE Yr='2019-20' AND Seasn='Rabi'*/

update d set RB_Code=m.DistCode from MSP.dbo.EP_Mst_District m inner join Seed_Mst_District d on m.LG_CODE=d.DistCode 
where Yr='2020-21' and Seasn='Kharif'

update Seed_Mst_District set seed_cell_order=33 where Yr='2020-21'and Seasn='Kharif' and DistCode=507 

select * from Seed_Mst_District where Yr='2020-21' and Seasn='Kharif'  order by seed_cell_order