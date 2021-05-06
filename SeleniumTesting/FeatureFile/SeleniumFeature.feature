Feature: SeleniumFeature
	In order to test functionality on epam website
    As a KPI student 
    I want to ensure it is working end to end

@keywordSearch
Scenario: Devops keyword search
    Given a web browser is on the Epam page
	And I have entered "devops" as a search keyword
    When I press the search button
    Then results for "devops" are shown

@servicesPage
Scenario: Going to Services page
	Given that I am on epam homepage
	When I click on services button
	Then the page title should consist "services" word

@translatePage
Scenario: Translating page to Polish
	Given that I am on epam homepage in English
	When I click on Global(EN) button
	And click on Polska (Polski)
	Then the page translates to polish

@searchJobs
Scenario: Searching jobs by a keyword
	Given that I am on epam homepage
	When I click on Careers button
	And write a "Lviv" keyword in according field
	Then results contain "Lviv" keyword

@filterInsights
Scenario: Filtering posts by Industries
	Given that I am on epam homepage
	When I click on Insights button
	And choose Healthcare in an industries filter list
	Then shown results concern healthcare themed posts

@filterInsights2
Scenario: Filtering posts by Industries and Content
	Given that I am on epam homepage
	When I click on Insights button
	And choose Healthcare in an industries filter list
	And choose Interviews in Content Types list
	Then shown results concern healthcare themed interviews

@searchJobsSkills
Scenario: Searching jobs by skills
	Given that I am on epam homepage
	When I click on Careers button
	And choose Data Analysis in skills list
	Then shown results contain Data related jobs

@searchJobsSkillsRemote
Scenario: Searching jobs by skills and remote work
	Given that I am on epam homepage
	When I click on Careers button
	And choose Software Engineering in skills list
	And check remote box
	Then shown results contain Software Engineering related jobs with a remote possibility