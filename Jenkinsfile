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
                sh 'chmod +x jenkins_test.bash'
                sh ''' 
                #!/bin/bash
                ./jenkins_test.bash
                '''
            }
        }
    }
}
