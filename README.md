# Sistema de Gerenciamento de Fila de Pacientes

Aplicação console em C# que simula um sistema de triagem hospitalar com classificação por prioridades.

## Funcionalidades

- **Cadastro de Pacientes**:
  - Registra nome, pressão arterial, temperatura e oxigenação
  - Classifica automaticamente a prioridade com base nos sinais vitais

- **Classificação por Prioridades**:
  - Vermelha (Crítico)
  - Amarela (Moderado) 
  - Verde (Leve)

- **Gerenciamento de Fila**:
  - Visualiza pacientes agrupados por prioridade
  - Atende automaticamente o paciente de maior prioridade
  - Mantém histórico completo de atendimentos

## Como Usar

```bash
1. Execute o programa
2. Escolha uma opção:
   - `cadastrar`: Adiciona novo paciente
   - `ver fila`: Mostra todos os pacientes por prioridade
   - `atender`: Atende paciente de maior prioridade
   - `sair`: Encerra e exibe histórico de atendimentos

FilaPacientes/
├── Paciente.cs          # Classe do paciente com lógica de prioridade
├── ClinicoGeral.cs      # Classe do médico com histórico
└── Program.cs           # Lógica principal da aplicação
