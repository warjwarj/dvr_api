pipeline {
    agent any
    stages {
        stage('Test') {
            steps {
                sh 'whoami'
                sh 'curl --unix-socket /var/run/docker.sock http:/images/json'
                sh 'dotnet --version'
            }
        }
    }
}
