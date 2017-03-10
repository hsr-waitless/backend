pipeline {
  agent any

  stages {
    stage('install') {
      steps {
        sh 'dotnet restore'
      }
    }

    stage('build') {
      steps {
	dir('WaitlessBackend') {
          sh 'dotnet build'
	}
      }
    }

    stage('test') {
      steps {
        dir('Test') {
          sh 'dotnet test'
        }
      }
    }
  }
}

