pipeline {
    agent {
        label 'docker-ssh-agent'
    }
    options {
        skipDefaultCheckout(true)
    }
    stages {
        stage('Test') {
            checkout scm
            steps {
                sh 'dotnet --version'
            }
        }
    }
}
