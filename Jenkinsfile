pipeline {
    agent none
    environment {
        DISABLE_AUTH = 'true'
        DB_ENGINE    = 'sqlite'
        DOTNET_CLI_HOME = "/tmp/DOTNET_CLI_HOME"
    }
    stages {
        stage('Test and Build'){
            agent {
                dockerfile{
                    filename 'Dockerfile'
                    dir '/var/jenkins_home/workspace/ShoppingCartAPI-DEV/docker/build-agent'
                }
            }
            stages {
                stage('Test Build Agent Environemt'){
                    steps{
                        echo "Navigating to source code"
                        sh '''
                        dotnet --info
                        '''
                    }
                }
                stage('Restore dotnet project'){
                    steps{
                        echo "Restore packages"
                        sh '''
                        dotnet restore "ShoppingCart.API.csproj"
                        '''
                    }
                }
                stage('Build dotnet project') {
                    steps {
                        echo "Building ShoppingCart.API.."
                        sh '''
                        cd /var/jenkins_home/workspace/ShoppingCartAPI-DEV/ShoppingCart.API
                        dotnet build "ShoppingCart.API.csproj" -c Release -o ../build
                        '''
                    }
                }
                stage('Test') {
                    steps {
                        echo "Testing.."
                        sh '''
                        echo "doing test stuff.."
                        '''
                        sh '''

                        '''
                    }
                }
                stage('Deliver') {
                    steps {
                        echo 'Deliver....'
                        sh '''
                        echo "doing delivery stuff.."
                        '''
                        sh '''


                        '''
                    }
                }
            }
        }
        
    }
}
