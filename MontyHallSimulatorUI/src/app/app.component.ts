import { Component } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  constructor(private service: SharedService, private toastr: ToastrService) {}

  title = 'MontyHallSimulatorUI';
  numberOfSimulations: number = 0;
  changeDoor: boolean = false;

  numberOfWins: number = 0;
  numberOfLosses: number = 0;

  isLoading: boolean = false;

  runSimulations() {
    if (
      this.numberOfSimulations == 0 ||
      this.numberOfSimulations > 2147483647
    ) {
      this.toastr.error('Please enter a valid number of simulations');
    } else {
      let data = {
        numberOfSimulations: this.numberOfSimulations,
        changeDoor: this.changeDoor,
      };
      this.isLoading = true;

      this.service.runSimulation(data).subscribe(
        (res: any) => {
          this.numberOfWins = res.wins;
          this.numberOfLosses = res.losses;
          this.isLoading = false;
        },
        (error) => {
          console.error(error);
          this.isLoading = false;
          this.toastr.error('Something went wrong');
        }
      );
    }
  }
}
