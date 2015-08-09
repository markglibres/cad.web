How to create angularjs controllers / modules

Follow the naming conventions to automatically resolve angularjs routes

1. Create your module on /app/components/{module name}
2. Create your controllers on /app/components/{module name}/controllers/{controller name}Controller.js
3. Create your views on /app/components/{module name}/views/{controller name}.html
4. To create url, use the directive mod-url. 
	
	For example: <a mod-url="test">Test</a>

	Will return:

	http://domain.com/Home  => http://domain.com/Home/#/test
	http://domain.com/Forms/Listing  => http://domain.com/Forms/Listing/#/test



	
