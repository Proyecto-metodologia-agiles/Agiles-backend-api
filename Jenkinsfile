node {

  stage('Checkout') {
    git  url: 'https://github.com/Proyecto-metodologia-agiles/Agiles-backend-api.git', branch: 'develop'
  }
  
  stage ('Restore Nuget') {
    //bat 'dotnet restore Agil.sln'
  }
  
  stage('Clean') {
    bat 'dotnet clean Agil.sln'
  }
  
  stage('Build') {
    bat 'dotnet build Agil.sln --configuration Release'
  }

    
  stage ('Question') {
	def userInput  = input( 'Do you approve deployment?' )
	 [$class: 'TextParameterDefinition', defaultValue: 'uat', description: 'Environment', name: 'env']
	echo ("Env: "+userInput)
  }

  stage('Publish') {
    bat 'dotnet publish Agil.sln -c Release -o C:/integracion_continua'
  }
	

	
  stage('Report Email') {
      emailext body: 'Se terminó de desplegar', subject: 'Test - Se termino de desplegar', to: 'grovveip@gmail.com'
  }
   
}
