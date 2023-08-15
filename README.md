﻿# BDOBook

## Intro

We have put this scenario together to see how you might deal with a real-world coding task. **At your interview we would like you to present your solution (via screen share) to the tasks**, as you would do in a sprint review, and show us anything of note in your code. There are no right or wrong answers, the aim is to see the approaches and patterns you use to solve the problem and for us to discuss the pros and cons during the interview. We will expect you to present for 20-30 minutes with questions along the way from us.

Do make sure you read through everything here before you get started. 

## Prerequisites
You will need to install the following to build and run the code in this scenario:
- Node v12+ and npm (https://nodejs.org). *
- Visual Studio (Community or higher) or Visual Studio Code.
- (Optional) In Visual Studio, you might like the Markdown Editor extension to get a Markdown preview for this file.

## Scenario
BDO think Yammer is overcomplicated and have decided to implement their own, simple social network called BDOBook. We've made a start but need your help to add some more features.

## Tasks
1. On the homepage, display all Posts in reverse date order, showing the author's name, date and time posted and the post content. On page load, don't show more than ten posts at once. It is up to you how you allow the user to see more posts. Remember that we are not testing design skills, but some styling should be applied so the content is clear and readable.

2. We also want a feed of technology news on our site. Add a feed from https://www.thenewsapi.com/ with the most recent 5 technology headlines. It is up to you if you also want to limit the news sources. This should be displayed as a sidebar on the home page. You will need to create an account to get an API token but the service is free for development. Feel free to use any appropriate libraries you need.

3. Create a simple profile page to display a given profile. This should simply be a page that displays the user's name, job title and shows a feed of their latest posts in reverse date order. Where there are posts on the homepage, add hyperlinks to the author names that lead to the appropriate profile page.

4. Add at least one unit test. This can be testing any appropriate part of the application.

## General guidance
- The project uses a Razor Pages template. If you'd prefer to use MVC, feel free to switch the template.
- The application uses EntityFramework with a file-based database to avoid you needing to set up a SQL server. On first run, a folder called *_database* will appear in your root folder. You do not need to do anything with these files, but feel free to look at them. Some initial data will have been seeded. This provider does not require migrations.
- For this application to be complete there would need to be an account and authentication system. This is not in place (and we do not expect you to add it) to make development easier for the purposes of these tasks.
- There is a Create Post page where you can create posts on behalf of any of the users in the system, there is a link in the header.
- We don't expect you to spend lots of time making this application look beautiful. **We are interested in *usability*, but not *design***.
- If we have not specified any implementation details, it is up to you to decide how to go about it.
- You are free to use any libraries that you need.
- We will be looking at your coding style. You may want to install something that will enforce consistent coding style.
- We will discuss your solutions and explore how you have gone about the tasks in your interview.

#### * Note on Node/NPM
- Node is used to run Gulp, a task runner, to pre-compile the SASS files into CSS. This is run as part of the build and if you have Node and NPM installed should run without issue. We do not expect you to configure this any further.