node {

  stage('Checkout') {
    git  url: 'https://github.com/Proyecto-metodologia-agiles/Agiles-backend-api.git', branch: 'develop'
  }
  
  stage ('Restore Nuget') {
    bat "dotnet restore Agil.sln"
  }
  
  stage('Clean') {
    bat 'dotnet clean '
  }
  
  stage('Build') {
    bat 'dotnet build  --configuration Release'
  }

  //stage ('Test') {
    //bat "dotnet test Presupuesto.Core.Domain.Test/Presupuesto.Core.Domain.Test.csproj --logger trx;LogFileName=unit_tests.trx"
    //mstest testResultsFile:"**/*.trx", keepLongStdio: true
  //}
    
  stage ('Question') {
	def userInput  = input( 'Do you approve deployment?' )
	 [$class: 'TextParameterDefinition', defaultValue: 'uat', description: 'Environment', name: 'env']
	echo ("Env: "+userInput)
  }

  stage('Publish') {
    bat 'dotnet publish -c Release -o C:/integracion_continua'
  }
  
  stage('Report Email') {
      emailext body: 'Se terminó de desplegar', subject: 'Test - Se termino de desplegar', to: 'grovveip@gmail.com'
  }
  
  
  
}