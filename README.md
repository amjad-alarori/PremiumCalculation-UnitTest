# PremiumCalculation-UnitTest
C# Windesheim opdracht


```
  _____          _____   _____ _    _ _____  ______ 
 / ____|   /\   |  __ \ / ____| |  | |  __ \|  ____|
| |       /  \  | |__) | (___ | |  | | |__) | |__   
| |      / /\ \ |  _  / \___ \| |  | |  _  /|  __|  
| |____ / ____ \| | \ \ ____) | |__| | | \ \| |____ 
 \_____/_/    \_\_|  \_\_____/ \____/|_|  \_\______|
```
VehicleTest:

- OldVehicleConstructionYearTest

		•Het doel van de unittest: 
 		Om te testen als de app de leeftijd van de auto kan in jaren berekenen.


		•Waarom heb je voor deze specifieke (data) invulling van de unittest hebt gekozen:
		ik heb 2017 als constructionYear gekozen omdat de app gaat de constructionYear aftrekken van de nu date als het hoger is.
		Age = constructionYear > DateTime.Now.Year ? 0 : DateTime.Now.Year - constructionYear;  

		•Welke technieken je gebruikthebt om tot deze data te komen
		Door de [assembly: InternalsVisibleTo("UnitTest")] iin de assebly.info file te zetten kon ik access krijgen naar elke object in de app, en zo kon ik de vehicle oproepen. Daarbij had ik [Fact] gebrukt om een test te maken.


- FreshVehicleConstructionYearTest:

		•Het doel van de unittest: 
 		Om te testen als de app de leeftijd van de auto kan in jaren berekenen.


		•Waarom heb je voor deze specifieke (data) invulling van de unittest hebt gekozen:
		ik heb DateTime.Now.Year als constructionYear gekozen omdat de app gaat de constructionYear checken als het date van nu heeft dan geeft he 0 terug.
		Age = constructionYear > DateTime.Now.Year ? 0 : DateTime.Now.Year - constructionYear;  

		•Welke technieken je gebruikthebt om tot deze data te komen
		Door de [assembly: InternalsVisibleTo("UnitTest")] iin de assebly.info file te zetten kon ik access krijgen naar elke object in de app, en zo kon ik de vehicle oproepen. Daarbij had ik [Fact] gebrukt om een test te maken.

- UpComingVehicleConstructionYearTest

		•Het doel van de unittest: 
 		Om te testen als de app de leeftijd van de auto kan in jaren berekenen.


		•Waarom heb je voor deze specifieke (data) invulling van de unittest hebt gekozen:
		ik heb DateTime.Now.Year + 1 als constructionYear gekozen omdat de app gaat de constructionYear checken als het date van toekomst of nu heeft dan geeft he 0 terug.
		Age = constructionYear > DateTime.Now.Year ? 0 : DateTime.Now.Year - constructionYear;  

		•Welke technieken je gebruikthebt om tot deze data te komen
		Door de [assembly: InternalsVisibleTo("UnitTest")] in de assebly.info file te zetten kon ik access krijgen naar elke object in de app, en zo kon ik de vehicle oproepen. Daarbij had ik [Fact] gebrukt om een test te maken.








 PremiumCalculationTest:

 - Procent15AddedToPremiumWhenUnder5YearsDriveLicenseStartDate

 		•Het doel van de unittest:

 		Om te testen als de PolicyHolder %15 meer op zijn preime krijgt als hij minder dan 5 jaar rij ervaring heeft in jonger dan 23 jaar is


		•Waarom heb je voor deze specifieke (data) invulling van de unittest hebt gekozen:

		Ik heb "22-07-2020" als start datum voor de rijbewijs gekozen omdat het ongeveer alleen 1 jaar verschil in vergelijk met nu in dat is dus minder 5 jaar. Voor de leeftijd heb ik 22 ingevulld omdat het minder dan 23 is.
 

		•Welke technieken je gebruikthebt om tot deze data te komen:

		Ik heb [Theory] gebruikt omm de inlinedata als paramiters in de functie te brengen zodat ik ze kan gebruiken met vergelijken tussen actual en expected.


 - Procent15AddedToPremiumWhenAbove5YearsDriveLicenseStartDate

 		•Het doel van de unittest: 

 		Om te testen als de PolicyHolder geen %15 meer op zijn preime krijgt als hij meer dan 5 jaar rij ervaring heeft en boven de 23 jaar is.


		•Waarom heb je voor deze specifieke (data) invulling van de unittest hebt gekozen:

		Ik heb "22-07-2010" als start datum voor de rijbewijs gekozen omdat het ongeveer 10 jaar verschil in vergelijk met nu in dat is dus meer dan 5 jaar. Voor de leeftijd heb ik 26 ingevulld omdat het meer dan 23 is. 
 

		•Welke technieken je gebruikthebt om tot deze data te komen:

		Ik heb [Theory] gebruikt omm de inlinedata als paramiters in de functie te brengen zodat ik ze kan gebruiken met vergelijken tussen actual en expected.



  - UpdatePremiumForNoClaimYearsTest

 		•Het doel van de unittest: 

 		Om te testen als de PolicyHolder %5 korting krijgt als hij vrijschade jaren heeft.


		•Waarom heb je voor deze specifieke (data) invulling van de unittest hebt gekozen:
 		
 		Ik heb twee objecten gemaakt met verschellinde Claim Years om die te vergelijken met elkaar en testen als de logica klopt in de Code.


		•Welke technieken je gebruikthebt om tot deze data te komen

		Ik heb [Fact] gebruikt en gewoon de paramiters van elke gemaakte object zelf aangepast 

 - PremiumPaymentAmountMonthTest

		•Het doel van de unittest: 

		Om te testen hoeveel preime moet de PolicyHolder betalen als hij de premie mandelijks gaat betalen.


		•Waarom heb je voor deze specifieke (data) invulling van de unittest hebt gekozen:
 		
 		Als tegenstelling van de oorspronkelijk berekening die stelt dat de PolicyHolder %2.5 korting krijgt als hij jaarlijks betaald, heb ik hier getest dat hij niet die korting zal krijgen als hij per maand betaald.


		•Welke technieken je gebruikthebt om tot deze data te komen

		Ik heb Mock gebruikt om de vhicle, policyholder objecten te mocken.


 - PremiumPaymentAmountYearTest

		•Het doel van de unittest: 

		Om te testen als de PolicyHolder %2.5 korting kriijgt als hij ervoor gekozen om jaarlijks te betalen.


		•Waarom heb je voor deze specifieke (data) invulling van de unittest hebt gekozen:
 
		Ik heb de premuim X * 0.975 om als resultaat de premie minder %2.5 te krijgen.


		•Welke technieken je gebruikthebt om tot deze data te komen

		Ik heb [Fact] gebruikt en gewoon de paramiters van elke gemaakte object zelf aangepast 


 - UpdatePremuimForPostalCodeTest

		•Het doel van de unittest: 

		Die gaat testen als wat voor korting de policyHolder gaat krijgen op bases van zijn post code


		•Waarom heb je voor deze specifieke (data) invulling van de unittest hebt gekozen:

		Omdat in de oorspronkelijk functie staat dat de postcode tussen de 1000 en de 3600 krijgt %5 meer op de prieme, en tussen 3600 en 4500 %2, en alles behalve dat krijgt geen verhoging.


		•Welke technieken

		Ik heb [Theory] gebruikt omm de inlinedata als paramiters in de functie te brengen zodat ik ze kan gebruiken met vergelijken tussen actual en expected.













Deel 2:Beschrijf de eventuele fouten in deze applicatie die je hebt gevonden tijdens het testen.


- UpdatePremiumForNoClaimYears

•Wat heb je getest?
 De UpdatePremiumForNoClaimYears als de PolicyHolder in aanmerking komt voor korting of niet

•Wat had je verwacht?

Ik had nummer type double verwacht aangezien dat de actual na de berekening met veel nummer achter de komma zal komen.

•Waar komt deze verwachting vandaan?

Toen ik het zonder de data type double heb gedraaid blijkt een error te geven omdat de app gaat van zelf afronden omhoog of omlaag, en dit dus niet goed als ik vergelijkt proces in de unit test met de Expected value wil maken.



- UpdatePremiumForNoClaimYears

•Wat heb je getest?
 De UpdatePremiumForNoClaimYears als de PolicyHolder in aanmerking komt voor korting of niet

•Wat had je verwacht?

Ik had nummer type double verwacht aangezien dat de actual na de berekening met veel nummer achter de komma zal komen.

•Waar komt deze verwachting vandaan?

Toen ik het zonder de data type double heb gedraaid blijkt een error te geven omdat de app gaat van zelf afronden omhoog of omlaag, en dit dus niet goed als ik vergelijkt proces in de unit test met de Expected value wil maken.




- CalculateBasePremium

•Wat heb je getest?
 De base premie overal gebruikt en opgeroepen in de unit test

•Wat had je verwacht?

Ik had nummer type double verwacht aangezien dat de Expected na de berekening met veel nummer achter de komma zal komen.

•Waar komt deze verwachting vandaan?

Toen ik het zonder de data type double heb gedraaid blijkt een error te geven omdat de app gaat van zelf afronden omhoog of omlaag, en dit dus niet goed als ik vergelijkt proces in de unit test met de actual en de Expected value wil maken.












