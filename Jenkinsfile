pipeline {
    agent {
        label 'docker-ssh-agent'
    }
    options {
        skipDefaultCheckout(true)
    }
    stages {
        stage('Test') {
            steps {
                checkout scm
                sh 'dotnet --version'
                sh ''' 
                #!/bin/bash
                ./jenkins_test.bash
                '''
            }
        }
    }
}
