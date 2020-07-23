﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Take_Home_Challenge.DialogService.DialogViewModels
{
    interface IEditPersonDialogViewModel
    {
        string Name { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
        bool IsActive { get; set; }

        void ConfirmEditPerson(object o);

        void CancelEditPerson(object obj);
    }
}