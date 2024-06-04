pipeline {
    agent any
    stages {
        stage('Test') {
            steps {
                sh 'docker ps'
                sh 'whoami'
                sh 'curl --unix-socket /var/run/docker.sock http:/images/json'
                sh 'dotnet --version'
            }
        }
    }
}
