/*
10 Manipulação de Arquivos: Escrita
Crie uma página SaveNote.cshtml que permita ao usuário escrever um texto e
salvá-lo em arquivo .txt no wwwroot/files.

Tarefas:
Use um InputModel com uma propriedade Content.
Ao submeter, crie um arquivo com nome note-{timestamp}.txt.
Confirme a escrita e exiba link para download.*/

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EXE11.Pages
{
    public class SaveNoteModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;

        public SaveNoteModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();
        public string? NomeArquivo { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            string pastaArquivos = Path.Combine(_environment.WebRootPath, "arquivosEXE10");

            Directory.CreateDirectory(pastaArquivos);

            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            NomeArquivo = $"note-{timestamp}.txt";

            string caminhoCompleto = Path.Combine(pastaArquivos, NomeArquivo);

            using (var writer = new StreamWriter(caminhoCompleto))
            {
                await writer.WriteAsync(Input.Content);
            }

            return Page();

        }


        public class InputModel
        {
            [Required(ErrorMessage = "O texto a ser gravado no arquivo é obrigatório.")]
            public string Content { get; set; } = string.Empty;
        }


    }
}
