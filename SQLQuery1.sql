--SET IDENTITY_INSERT Hist_Detail ON;
--SET IDENTITY_INSERT Hist_Generale ON;
--SET IDENTITY_INSERT Enfant_Hist_Detail ON;
--SET IDENTITY_INSERT Enfant_Hist_Generale ON;
--SET IDENTITY_INSERT Parent ON;
--SET IDENTITY_INSERT Parent_Enfant ON;

Delete FROM Enfant_Hist_Detail;
Delete From Hist_Detail;
Delete  From Enfant_Hist_generale;
Delete From Hist_generale;
declare @IDTEST BIGINT;
INSERT INTO Hist_Detail(niveau,score,Op1,Op2,Op3,Op4,Op5,Op6,Op7,Op8,Op9,Op10,Op11,Op12,Op13,Op14,Op15,
															Op16,
															Op17,
															Op18,
															Op19,
															Op20,
															Sol1,Sol2,Sol3,Sol4,Sol5,Sol6,Sol7,Sol8,Sol9,Sol10,Sol11,Sol12,Sol13,Sol14,Sol15,
															Sol16,
															Sol17,
															Sol18,
															Sol19,
															Sol20)
VALUES(2,20,'2*2','2*2','2*2','2*2','2*2',
'2*2','2*2','2*2','2*2','2*2',
'2*2','2*2','2*2','2*2','2*2',
'2*2','2*2','2*2','2*2','2*2',
'4','4','4','4','4',
'4','4','4','4','4',
'4','4','4','4','4',
'4','4','4','4','4');
select @IDTEST=SCOPE_IDENTITY();
Declare @ID INT;

SET IDENTITY_INSERT Hist_Generale off;
Insert into Hist_generale(niveau,score) VALUES (2,1);
Select @ID=SCOPE_IDENTITY();
Insert into Enfant_Hist_generale(id_enfant,id_hist_generale) VALUES (1,@ID);
INSERT INTO Enfant_Hist_Detail(id_enfant,id_hist) VALUES(1,@IDTEST);

Select Gen.niveau as lvl,  Gen.score 
from Hist_generale as Gen, Enfant_Hist_generale as EnfGen, Enfant as Enf
where Enf.id_enfant=EnfGen.id_enfant and EnfGen.id_hist_generale=Gen.id_hist_generale


Select niveau 
from Hist_generale as Gen ,  Enfant_Hist_generale as EnfGen, Enfant as Enf
where Enf.prenom='olivier' and Enf.nom='mertz'
and Enf.id_enfant=EnfGen.id_enfant and EnfGen.id_hist_generale=Gen.id_hist_generale
/*(id_hist_detail,niveau,score,Op1,Op2,Op3,Op4,Op5,Op6,Op7,Op8,Op9,Op10,Op11,Op12,Op13,Op14,Op15,
															Op16,
															Op17,
															Op18,
															Op19,
															Op20,
															Sol1,Sol2,Sol3,Sol4,Sol5,Sol6,Sol7,Sol8,Sol9,Sol10,Sol11,Sol12,Sol13,Sol14,Sol15,
															Sol16,
															Sol17,
															Sol18,
															Sol19,
															Sol20)
															*/