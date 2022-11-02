- The user can make 4 request out of which two requests are only made if the user is authorized.
- So, Initially the user register and authenticates him then the user logs in and gets authorized.
- Once the user is authorized he can create orders and view them by page no and page size


Logic for viewing: 
{
	Page size : the no of orers he wants to view in a page.
	page no. the page he wants to visit.
	
	if the person wants to view a page with no orders then he is given a message telling he needs to add order or change is page no.

	It can also handle a situation where a person wants to view 10 items in a 1st page and there are only 7 items, the api requests views the 7 items alone  	without causing an error
}

