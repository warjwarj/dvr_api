pipeline {
    agent {
        label 'docker-ssh-agent'
    }
    stages {
        stage('Test') {
            steps {
                sh 'dotnet --version'
            }
        }
    }
}
